CREATE ROLE [Teacher_ReadWrite]
GO
/****** Object:  DatabaseRole [Teacher_ReadOnly]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE ROLE [Teacher_ReadOnly]
GO
/****** Object:  DatabaseRole [Payroll_Clerk]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE ROLE [Payroll_Clerk]
GO
/****** Object:  DatabaseRole [Manager]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE ROLE [Manager]
GO
/****** Object:  DatabaseRole [Admin]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE ROLE [Admin]
GO
/****** Object:  Schema [AdminOps]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SCHEMA [AdminOps]
GO
/****** Object:  Schema [Payroll]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SCHEMA [Payroll]
GO
/****** Object:  Schema [Teachers]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SCHEMA [Teachers]
GO

USE [trungtamtienganh];
GO

-- Admin: full control over database (without using db_owner if you prefer)
GRANT CONTROL ON DATABASE::[trungtamtienganh] TO [Admin];
GO

-- Manager: read access to Teachers schema + payroll employee info view
GRANT SELECT ON SCHEMA::[Teachers] TO [Manager];
GRANT SELECT ON OBJECT::[Payroll].[EmployeeInfo] TO [Manager];
GO

-- Payroll clerk: read employee info + execute salary calculation only
GRANT SELECT  ON OBJECT::[Payroll].[EmployeeInfo] TO [Payroll_Clerk];

-- Explicitly deny direct access to salaries table (defense-in-depth)
IF OBJECT_ID(N'Payroll.Salaries', 'U') IS NOT NULL
    DENY SELECT ON OBJECT::[Payroll].[Salaries] TO [Payroll_Clerk];
GO

-- Teachers
GRANT SELECT ON SCHEMA::[Teachers] TO [Teacher_ReadOnly];

GRANT SELECT, INSERT, UPDATE ON SCHEMA::[Teachers] TO [Teacher_ReadWrite];
-- intentionally no DELETE; grant explicitly if needed
GO

CREATE VIEW [Teachers].[MyClasses] AS
SELECT c.id, c.class_code, c.course_id, c.start_date, c.end_date, c.status
FROM dbo.classes c;
GO

CREATE   VIEW [Teachers].[MyEnrollments]
AS
SELECT 
    e.id, e.class_id, s.student_code, s.full_name, e.status, e.final_fee
FROM dbo.enrollments e
JOIN dbo.students s ON s.id = e.student_id;
GO

CREATE   VIEW [Teachers].[MyAttendance]
AS
SELECT 
    a.id, a.class_id, s.student_code, s.full_name,
    a.session_date, a.session_number, a.status
FROM dbo.attendance a
JOIN dbo.students s ON s.id = a.student_id;
GO

CREATE VIEW [Teachers].[MyAssessments]
AS
SELECT 
    s.student_code, s.full_name,
    a.class_id, a.homework_score, a.midterm_score, a.final_score, a.total_score, a.result
FROM dbo.assessments a
JOIN dbo.students s ON s.id = a.student_id;
GO

CREATE OR ALTER VIEW [Payroll].[EmployeeInfo]
AS
SELECT 
    st.id AS StaffId,
    st.full_name,
    st.[role],
    st.employment_type,
    st.[status],
    st.hire_date
FROM dbo.[staff] AS st
WHERE st.[status] IN ('Active','Onboarding');
GO

CREATE VIEW [AdminOps].[PerformanceSummary]
AS
SELECT 
    pr.staff_id,
    st.full_name,
    pr.period,
    pr.completion_rate,
    pr.feedback_score,
    pr.retention_impact,
    pr.overall_rating,
    pr.reviewer,
    pr.comments
FROM dbo.performance_reviews pr
JOIN dbo.staff st ON st.id = pr.staff_id;
GO

CREATE FUNCTION [AdminOps].[fn_rls_attendance](@class_id UNIQUEIDENTIFIER)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN (
  SELECT 1 AS allow_access
  FROM dbo.classes c
  WHERE c.id = @class_id
    AND c.teacher_id = CONVERT(UNIQUEIDENTIFIER, SESSION_CONTEXT(N'StaffId'))
);

CREATE FUNCTION [AdminOps].[fn_rls_assessments](@class_id UNIQUEIDENTIFIER)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN (
  SELECT 1 AS allow_access
  FROM dbo.classes c
  WHERE c.id = @class_id
    AND c.teacher_id = CONVERT(UNIQUEIDENTIFIER, SESSION_CONTEXT(N'StaffId'))
);

CREATE FUNCTION [AdminOps].[fn_rls_enrollments](@class_id UNIQUEIDENTIFIER)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN (
  SELECT 1 AS allow_access
  FROM dbo.classes c
  WHERE c.id = @class_id
    AND c.teacher_id = CONVERT(UNIQUEIDENTIFIER, SESSION_CONTEXT(N'StaffId'))
);

CREATE   FUNCTION [AdminOps].[fn_has_valid_cert](@StaffId UNIQUEIDENTIFIER)
RETURNS BIT
AS
BEGIN
    DECLARE @ok BIT = 0;

    -- TESOL / CELTA → chỉ cần verify & còn hạn
    IF EXISTS (
        SELECT 1
        FROM dbo.qualifications q
        WHERE q.staff_id = @StaffId
          AND q.is_verified = 1
          AND (q.expiry_date IS NULL OR q.expiry_date >= CAST(GETDATE() AS DATE))
          AND q.qualification_type IN ('TESOL','CELTA')
    )
        SET @ok = 1;

    -- IELTS ≥ 7.0
    IF EXISTS (
        SELECT 1
        FROM dbo.qualifications q
        WHERE q.staff_id = @StaffId
          AND q.is_verified = 1
          AND (q.expiry_date IS NULL OR q.expiry_date >= CAST(GETDATE() AS DATE))
          AND q.qualification_type = 'IELTS'
          AND q.score >= 7.0
    )
        SET @ok = 1;

    -- TOEFL ≥ 80
    IF EXISTS (
        SELECT 1
        FROM dbo.qualifications q
        WHERE q.staff_id = @StaffId
          AND q.is_verified = 1
          AND (q.expiry_date IS NULL OR q.expiry_date >= CAST(GETDATE() AS DATE))
          AND q.qualification_type = 'TOEFL'
          AND q.score >= 80
    )
        SET @ok = 1;

    RETURN @ok;
END;
GO

/****** Object:  SecurityPolicy [AdminOps].[sp_rls_assessments]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SECURITY POLICY [AdminOps].[sp_rls_assessments] 
ADD FILTER PREDICATE [AdminOps].[fn_rls_assessments]([class_id]) ON [dbo].[assessments],
ADD BLOCK PREDICATE [AdminOps].[fn_rls_assessments]([class_id]) ON [dbo].[assessments]
WITH (STATE = ON, SCHEMABINDING = ON)
GO
/****** Object:  SecurityPolicy [AdminOps].[sp_rls_attendance]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SECURITY POLICY [AdminOps].[sp_rls_attendance] 
ADD FILTER PREDICATE [AdminOps].[fn_rls_attendance]([class_id]) ON [dbo].[attendance],
ADD BLOCK PREDICATE [AdminOps].[fn_rls_attendance]([class_id]) ON [dbo].[attendance]
WITH (STATE = ON, SCHEMABINDING = ON)
GO
/****** Object:  SecurityPolicy [AdminOps].[sp_rls_classes]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SECURITY POLICY [AdminOps].[sp_rls_classes] 
ADD FILTER PREDICATE [AdminOps].[fn_rls_classes]([teacher_id]) ON [dbo].[classes],
ADD BLOCK PREDICATE [AdminOps].[fn_rls_classes]([teacher_id]) ON [dbo].[classes]
WITH (STATE = ON, SCHEMABINDING = ON)
GO
/****** Object:  SecurityPolicy [AdminOps].[sp_rls_enrollments]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE SECURITY POLICY [AdminOps].[sp_rls_enrollments] 
ADD FILTER PREDICATE [AdminOps].[fn_rls_enrollments]([class_id]) ON [dbo].[enrollments],
ADD BLOCK PREDICATE [AdminOps].[fn_rls_enrollments]([class_id]) ON [dbo].[enrollments]
WITH (STATE = ON, SCHEMABINDING = ON)
GO

CREATE OR ALTER PROCEDURE [AdminOps].[GetEmployeeInfo]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.[id],
        s.[full_name],
        s.[phone],
        s.[email],
        s.[role],
        s.[employment_type],
        s.[status],
        s.[hire_date],
        s.[termination_date],
        s.[contact_info],
        s.[bank_account],
        s.[tax_code],
        s.[created_at],
        q.[qualification_type]
    FROM [trungtamtienganh].[dbo].[staff] AS s
    LEFT JOIN [trungtamtienganh].[dbo].[qualifications] AS q
        ON q.[staff_id] = s.[id]
    ORDER BY s.[full_name];
END
GO

CREATE PROCEDURE [AdminOps].[sp_AddQualification]
    @StaffId UNIQUEIDENTIFIER,
    @QualificationType NVARCHAR(50),
    @IssuingOrganization NVARCHAR(100),
    @Score DECIMAL(12,2) = NULL,
    @IssueDate DATE,
    @ExpiryDate DATE = NULL,
    @IsVerified BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO dbo.qualifications(id, staff_id, qualification_type, issuing_organization, score, issue_date, expiry_date, is_verified, created_at)
        VALUES(NEWID(), @StaffId, @QualificationType, @IssuingOrganization, @Score, @IssueDate, @ExpiryDate, @IsVerified, GETDATE());

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;

    END CATCH
END;
GO
--nghiệp vụ
CREATE   PROCEDURE [AdminOps].[sp_AddStaff]
    @FullName NVARCHAR(100),
    @Role NVARCHAR(20),
    @EmploymentType NVARCHAR(20),
    @Phone NVARCHAR(15) = NULL,
    @Email NVARCHAR(100) = NULL,
    @HireDate DATE = NULL,
    @contact_info NVARCHAR(MAX) = NULL,
    @bank_account NVARCHAR(50) = NULL,
    @tax_code NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @NewStaffId UNIQUEIDENTIFIER = NEWID();
        INSERT INTO dbo.staff(id, full_name, role, employment_type, status, phone, email, hire_date,contact_info,bank_account, tax_code, created_at)
        VALUES(@NewStaffId, @FullName, @Role, @EmploymentType, 'Onboarding', @Phone, @Email, @HireDate,@contact_info,@bank_account, @tax_code, GETDATE());

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [AdminOps].[sp_GetStaff]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE PROCEDURE [AdminOps].[sp_GetStaff]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        full_name,
        phone,
        email,
        role,
        employment_type,
        status,
        hire_date,
        termination_date,
        contact_info,
        bank_account,
        tax_code,
        created_at
    FROM dbo.staff;
END
GO
/****** Object:  StoredProcedure [Payroll].[sp_AddContract]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE PROCEDURE [Payroll].[sp_AddContract]
    @StaffId UNIQUEIDENTIFIER,
    @ContractType NVARCHAR(20),
    @StartDate DATE,
    @EndDate DATE,
    @salarymodel NVARCHAR(20),
    @BaseSalary DECIMAL(12,2) = NULL,
    @HourlyRate DECIMAL(12,2) = NULL,
    @Allowances DECIMAL(12,2) = 0,
    @BonusPolicy DECIMAL(12,2) = 0,
    @Message NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        -- Validate hợp đồng
        IF @ContractType = 'Full-time' AND @BaseSalary IS NULL
        BEGIN
            SET @Message = N'Hợp đồng Full-time phải có BaseSalary';
            ROLLBACK TRAN; RETURN;
        END;

        IF @ContractType IN ('Part-time','Freelance') AND @HourlyRate IS NULL
        BEGIN
            SET @Message = N'Hợp đồng Part-time/Freelance phải có HourlyRate';
            ROLLBACK TRAN; RETURN;
        END;

        -- Nếu là Teacher thì check chứng chỉ hợp lệ
        IF EXISTS (SELECT 1 FROM dbo.staff WHERE id=@StaffId AND role='Teacher')
        BEGIN
            IF (SELECT AdminOps.fn_has_valid_cert(@StaffId)) = 0
            BEGIN
                SET @Message = N'Giáo viên bắt buộc có chứng chỉ hợp lệ trước khi ký hợp đồng.';
                ROLLBACK TRAN; RETURN;
            END
        END

        -- Insert hợp đồng
        INSERT INTO dbo.contracts(id, staff_id, contract_type, start_date, end_date, base_salary,salary_model, hourly_rate, allowances, bonus_policy, created_at)
        VALUES(NEWID(), @StaffId, @ContractType, @StartDate, @EndDate, @BaseSalary, @salarymodel, @HourlyRate, @Allowances, @BonusPolicy, GETDATE());

        -- Update trạng thái nhân viên
        UPDATE dbo.staff SET status='Active' WHERE id=@StaffId;

        COMMIT TRAN;
        SET @Message = N'Hợp đồng đã được tạo thành công.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SET @Message = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE [AdminOps].[sp_GetStaffAllById]
    @StaffId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Staff
    SELECT 
        s.id,
        s.full_name,
        s.phone,
        s.email,
        s.[role],
        s.employment_type,
        s.[status],
        s.hire_date,
        s.termination_date,
        s.contact_info,
        s.bank_account,
        s.tax_code,
        s.created_at
    FROM dbo.[staff] AS s
    WHERE s.id = @StaffId;

    -- 2) Qualifications
    SELECT 
        q.id,
        q.staff_id,
        q.qualification_type,
        q.issuing_organization,
        q.score,
        q.issue_date,
        q.expiry_date,
        q.is_verified,
        q.created_at
    FROM dbo.[qualifications] AS q
    WHERE q.staff_id = @StaffId
    ORDER BY q.issue_date DESC, q.created_at DESC;

    -- 3) Contracts
    SELECT 
        c.id,
        c.staff_id,
        c.contract_type,
        c.start_date,
        c.end_date,
        c.salary_model,
        c.base_salary,
        c.hourly_rate,
        c.allowances,
        c.bonus_policy,
        c.created_at
    FROM dbo.[contracts] AS c
    WHERE c.staff_id = @StaffId
    ORDER BY c.start_date DESC, c.created_at DESC;
END
GO

CREATE OR ALTER PROCEDURE [AdminOps].[sp_UpdateStaff]
    @StaffId UNIQUEIDENTIFIER,
    @FullName NVARCHAR(100) = NULL,
    @Role NVARCHAR(30) = NULL,
    @EmploymentType NVARCHAR(20) = NULL,
    @Phone NVARCHAR(15) = NULL,
    @Email NVARCHAR(100) = NULL,
    @HireDate DATE = NULL,
    @TerminationDate DATE = NULL,
    @contact_info NVARCHAR(MAX) = NULL,
    @bank_account NVARCHAR(50) = NULL,
    @tax_code NVARCHAR(50) = NULL,
    @Status NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.[staff] WHERE id = @StaffId)
            THROW 50001, 'Staff not found.', 1;

        UPDATE dbo.[staff]
        SET full_name       = COALESCE(@FullName, full_name),
            [role]          = COALESCE(@Role, [role]),
            employment_type = COALESCE(@EmploymentType, employment_type),
            phone           = COALESCE(@Phone, phone),
            email           = COALESCE(@Email, email),
            hire_date       = COALESCE(@HireDate, hire_date),
            termination_date= COALESCE(@TerminationDate, termination_date),
            contact_info    = COALESCE(@contact_info, contact_info),
            bank_account    = COALESCE(@bank_account, bank_account),
            tax_code        = COALESCE(@tax_code, tax_code),
            [status]        = COALESCE(@Status, [status])
        WHERE id = @StaffId;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [AdminOps].[sp_UpdateQualification]
    @QualificationId UNIQUEIDENTIFIER,
    @QualificationType NVARCHAR(50) = NULL,
    @IssuingOrganization NVARCHAR(100) = NULL,
    @Score DECIMAL(12,2) = NULL,
    @IssueDate DATE = NULL,
    @ExpiryDate DATE = NULL,
    @IsVerified BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.[qualifications] WHERE id = @QualificationId)
            THROW 50002, 'Qualification not found.', 1;

        UPDATE dbo.[qualifications]
        SET qualification_type   = COALESCE(@QualificationType, qualification_type),
            issuing_organization = COALESCE(@IssuingOrganization, issuing_organization),
            score                = COALESCE(@Score, score),
            issue_date           = COALESCE(@IssueDate, issue_date),
            expiry_date          = COALESCE(@ExpiryDate, expiry_date),
            is_verified          = COALESCE(@IsVerified, is_verified)
        WHERE id = @QualificationId;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Payroll].[sp_UpdateContract]
    @ContractId UNIQUEIDENTIFIER,
    @StaffId UNIQUEIDENTIFIER = NULL,
    @ContractType NVARCHAR(20) = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @SalaryModel NVARCHAR(20) = NULL,
    @BaseSalary DECIMAL(12,2) = NULL,
    @HourlyRate DECIMAL(12,2) = NULL,
    @Allowances DECIMAL(12,2) = NULL,
    @BonusPolicy DECIMAL(12,2) = NULL,
    @Message NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.[contracts] WHERE id = @ContractId)
        BEGIN
            SET @Message = N'Contract not found.';
            ROLLBACK TRAN; RETURN;
        END

        -- Load current values to validate after applying changes
        DECLARE @curStaffId UNIQUEIDENTIFIER,
                @curContractType NVARCHAR(20),
                @curSalaryModel NVARCHAR(20),
                @curBaseSalary DECIMAL(12,2),
                @curHourlyRate DECIMAL(12,2);

        SELECT @curStaffId = staff_id,
               @curContractType = contract_type,
               @curSalaryModel = salary_model,
               @curBaseSalary = base_salary,
               @curHourlyRate = hourly_rate
        FROM dbo.[contracts]
        WHERE id = @ContractId;

        SET @curStaffId     = COALESCE(@StaffId, @curStaffId);
        SET @curContractType= COALESCE(@ContractType, @curContractType);
        SET @curSalaryModel = COALESCE(@SalaryModel, @curSalaryModel);
        SET @curBaseSalary  = COALESCE(@BaseSalary, @curBaseSalary);
        SET @curHourlyRate  = COALESCE(@HourlyRate, @curHourlyRate);

        -- Validate rules like in sp_AddContract
        IF @curContractType = 'Full-time' AND @curBaseSalary IS NULL
        BEGIN
            SET @Message = N'Hợp đồng Full-time phải có BaseSalary';
            ROLLBACK TRAN; RETURN;
        END;

        IF @curContractType IN ('Part-time','Freelance') AND @curHourlyRate IS NULL
        BEGIN
            SET @Message = N'Hợp đồng Part-time/Freelance phải có HourlyRate';
            ROLLBACK TRAN; RETURN;
        END;

        IF EXISTS (SELECT 1 FROM dbo.[staff] WHERE id = @curStaffId AND [role] = 'Teacher')
        BEGIN
            IF (SELECT AdminOps.fn_has_valid_cert(@curStaffId)) = 0
            BEGIN
                SET @Message = N'Giáo viên bắt buộc có chứng chỉ hợp lệ trước khi cập nhật hợp đồng.';
                ROLLBACK TRAN; RETURN;
            END
        END

        UPDATE dbo.[contracts]
        SET staff_id      = COALESCE(@StaffId, staff_id),
            contract_type = COALESCE(@ContractType, contract_type),
            start_date    = COALESCE(@StartDate, start_date),
            end_date      = COALESCE(@EndDate, end_date),
            base_salary   = COALESCE(@BaseSalary, base_salary),
            salary_model  = COALESCE(@SalaryModel, salary_model),
            hourly_rate   = COALESCE(@HourlyRate, hourly_rate),
            allowances    = COALESCE(@Allowances, allowances),
            bonus_policy  = COALESCE(@BonusPolicy, bonus_policy)
        WHERE id = @ContractId;

        COMMIT TRAN;
        SET @Message = N'Cập nhật hợp đồng thành công.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        SET @Message = ERROR_MESSAGE();
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [AdminOps].[sp_DeleteQualification]
    @QualificationId UNIQUEIDENTIFIER,
    @Message NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.[qualifications] WHERE id = @QualificationId)
        BEGIN
            SET @Message = N'Không tìm thấy chứng chỉ.';
            ROLLBACK TRAN; RETURN;
        END

        DELETE FROM dbo.[qualifications]
        WHERE id = @QualificationId;

        COMMIT TRAN;
        SET @Message = N'Xóa chứng chỉ thành công.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        SET @Message = ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Payroll].[sp_DeleteContract]
    @ContractId UNIQUEIDENTIFIER,
    @Message NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @StaffId UNIQUEIDENTIFIER;

        SELECT @StaffId = c.staff_id
        FROM dbo.[contracts] AS c
        WHERE c.id = @ContractId;

        IF @StaffId IS NULL
        BEGIN
            SET @Message = N'Không tìm thấy hợp đồng.';
            ROLLBACK TRAN; RETURN;
        END

        -- Delete the contract
        DELETE FROM dbo.[contracts]
        WHERE id = @ContractId;

        -- Only terminate staff if no other active contracts remain
        IF NOT EXISTS (
            SELECT 1
            FROM dbo.[contracts]
            WHERE staff_id = @StaffId
              AND (end_date IS NULL OR end_date >= CAST(GETDATE() AS DATE))
        )
        BEGIN
            UPDATE dbo.[staff]
            SET [status] = 'Terminated',
                termination_date = COALESCE(termination_date, CAST(GETDATE() AS DATE))
            WHERE id = @StaffId;

            SET @Message = N'Xóa hợp đồng và cập nhật trạng thái nhân viên thành Terminated.';
        END
        ELSE
        BEGIN
            SET @Message = N'Xóa hợp đồng thành công. Nhân viên vẫn còn hợp đồng hoạt động.';
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        SET @Message = ERROR_MESSAGE();
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Payroll].[sp_GetTimesheetsByStaff]
    @StaffId    UNIQUEIDENTIFIER,
    @StartDate  DATE = NULL,
    @EndDate    DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        id,
        staff_id,
        work_date,
        hours_worked,
        [type],
        [status],
        created_at
    FROM dbo.timesheets
    WHERE staff_id = @StaffId
      AND (@StartDate IS NULL OR work_date >= @StartDate)
      AND (@EndDate   IS NULL OR work_date <= @EndDate)
    ORDER BY work_date DESC, created_at DESC;
END
GO

/****** Object:  StoredProcedure [Payroll].[sp_ApproveTimesheet]    Script Date: 9/23/2025 5:31:43 AM ******/
CREATE OR ALTER PROCEDURE [Payroll].[sp_ApproveTimesheet]
    @TimesheetId UNIQUEIDENTIFIER,
    @ApprovedBy   NVARCHAR(100),
    @Message      NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.timesheets WHERE id = @TimesheetId)
    BEGIN
        SET @Message = N'Timesheet not found.';
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.timesheets WHERE id = @TimesheetId AND status <> 'Pending')
    BEGIN
        SET @Message = N'Timesheet is not in Pending status.';
        RETURN;
    END

    UPDATE dbo.timesheets
    SET status       = 'Approved'
    WHERE id = @TimesheetId
      AND status = 'Pending';

    SET @Message = N'Approved successfully.';
END
GO

CREATE OR ALTER PROCEDURE [Payroll].[sp_GeneratePayroll]
    @PeriodStart DATE,
    @PeriodEnd   DATE
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Hours AS (
        SELECT t.staff_id,
               SUM(CASE WHEN t.type = 'Teaching'       THEN t.hours_worked ELSE 0 END) AS TeachingHours,
               SUM(CASE WHEN t.type = 'Administrative' THEN t.hours_worked ELSE 0 END) AS AdminHours
        FROM dbo.timesheets t
        WHERE t.work_date BETWEEN @PeriodStart AND @PeriodEnd
          AND t.status = 'Approved'
        GROUP BY t.staff_id
    ),
    ActiveContracts AS (
        SELECT c.*,
               ROW_NUMBER() OVER (
                   PARTITION BY c.staff_id
                   ORDER BY c.start_date DESC, c.created_at DESC
               ) AS rn
        FROM dbo.contracts c
        WHERE c.start_date <= @PeriodEnd
          AND (c.end_date IS NULL OR c.end_date >= @PeriodStart)
    )
    SELECT
        s.id AS staff_id,
        s.full_name,
        ac.contract_type,
        ac.base_salary, ac.hourly_rate, ac.allowances, ac.bonus_policy,
        ISNULL(h.TeachingHours, 0) AS TeachingHours,
        ISNULL(h.AdminHours,    0) AS AdminHours,
        CASE
            WHEN ac.contract_type = 'Full-time'
                THEN ISNULL(ac.base_salary,0) + ISNULL(ac.allowances,0) + ISNULL(ac.bonus_policy,0)
            WHEN ac.contract_type IN ('Part-time','Freelance')
                THEN ISNULL(ac.hourly_rate,0) * ISNULL(h.TeachingHours,0)
            ELSE 0
        END AS CalculatedSalary
    FROM dbo.staff s
    JOIN ActiveContracts ac ON ac.staff_id = s.id AND ac.rn = 1
    LEFT JOIN Hours h       ON h.staff_id = s.id
    ORDER BY s.full_name;
END
GO

CREATE OR ALTER PROCEDURE Payroll.sp_UpsertMonthlyTotals
    @Year  INT,
    @Month TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PeriodStart DATE = DATEFROMPARTS(@Year, @Month, 1);
    DECLARE @PeriodEnd   DATE = EOMONTH(@PeriodStart);

    ;WITH Hours AS (
        SELECT t.staff_id,
               SUM(CASE WHEN t.type='Teaching'       THEN t.hours_worked ELSE 0 END) AS TeachingHours,
               SUM(CASE WHEN t.type='Administrative' THEN t.hours_worked ELSE 0 END) AS AdminHours
        FROM dbo.timesheets t
        WHERE t.work_date BETWEEN @PeriodStart AND @PeriodEnd
          AND t.status='Approved'
        GROUP BY t.staff_id
    ),
    ActiveContracts AS (
        SELECT c.*,
               ROW_NUMBER() OVER (
                 PARTITION BY c.staff_id
                 ORDER BY c.start_date DESC, c.created_at DESC
               ) AS rn
        FROM dbo.contracts c
        WHERE c.start_date <= @PeriodEnd
          AND (c.end_date IS NULL OR c.end_date >= @PeriodStart)
    ),
    Calc AS (
        SELECT
            s.id AS staff_id,
            CASE
                WHEN ac.contract_type='Full-time'
                    THEN ISNULL(ac.base_salary,0) + ISNULL(ac.allowances,0) + ISNULL(ac.bonus_policy,0)
                WHEN ac.contract_type IN ('Part-time','Freelance')
                    THEN ISNULL(ac.hourly_rate,0) * ISNULL(h.TeachingHours,0)
                ELSE 0
            END AS MonthlyTotal
        FROM dbo.staff s
        JOIN ActiveContracts ac ON ac.staff_id = s.id AND ac.rn = 1
        LEFT JOIN Hours h ON h.staff_id = s.id
    )
    MERGE Payroll.staff_monthly_salary AS tgt
    USING (
        SELECT @Year AS period_year, @Month AS period_month, staff_id, MonthlyTotal
        FROM Calc
    ) AS src
    ON (tgt.staff_id = src.staff_id AND tgt.period_year = src.period_year AND tgt.period_month = src.period_month)
    WHEN MATCHED THEN
        UPDATE SET tgt.total_amount = src.MonthlyTotal  -- giữ nguyên disbursed_amount
    WHEN NOT MATCHED THEN
        INSERT (staff_id, period_year, period_month, total_amount, disbursed_amount)
        VALUES (src.staff_id, src.period_year, src.period_month, src.MonthlyTotal, 0);
END
GO

CREATE OR ALTER PROCEDURE Payroll.sp_AddMonthlyDisbursement
    @StaffId UNIQUEIDENTIFIER,
    @Year    INT,
    @Month   TINYINT,
    @Amount  DECIMAL(14,2),
    @Message NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Amount <= 0
    BEGIN
        SET @Message = N'Số tiền giải ngân phải > 0.'; RETURN;
    END

    IF NOT EXISTS (
        SELECT 1 FROM Payroll.staff_monthly_salary
        WHERE staff_id=@StaffId AND period_year=@Year AND period_month=@Month
    )
    BEGIN
        SET @Message = N'Chưa có dữ liệu tổng lương tháng để giải ngân. Hãy chạy sp_UpsertMonthlyTotals trước.';
        RETURN;
    END

    DECLARE @total DECIMAL(14,2), @paid DECIMAL(14,2);
    SELECT @total = total_amount, @paid = disbursed_amount
    FROM Payroll.staff_monthly_salary
    WHERE staff_id=@StaffId AND period_year=@Year AND period_month=@Month;

    IF @paid + @Amount > @total
    BEGIN
        SET @Message = N'Số tiền giải ngân vượt quá tổng lương tháng.'; RETURN;
    END

    UPDATE Payroll.staff_monthly_salary
    SET disbursed_amount = disbursed_amount + @Amount,
        last_disbursed_at = GETDATE()
    WHERE staff_id=@StaffId AND period_year=@Year AND period_month=@Month;

    SET @Message = N'Giải ngân thành công.';
END
GO

CREATE OR ALTER PROCEDURE Payroll.sp_GetMonthlySalary
    @Year  INT,
    @Month TINYINT,
    @StaffId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT l.staff_id, s.full_name,
           l.period_year, l.period_month,
           l.total_amount, l.disbursed_amount, (l.total_amount - l.disbursed_amount) AS remaining,
           l.last_disbursed_at, l.created_at
    FROM Payroll.staff_monthly_salary l
    JOIN dbo.staff s ON s.id = l.staff_id
    WHERE l.period_year = @Year
      AND l.period_month = @Month
      AND (@StaffId IS NULL OR l.staff_id = @StaffId)
    ORDER BY s.full_name;
END
GO

CREATE OR ALTER PROCEDURE [AdminOps].[sp_DeleteStaffIfTerminated]
    @StaffId  UNIQUEIDENTIFIER,
    @Message  NVARCHAR(200) OUTPUT,
    @Success  BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM dbo.staff WHERE id = @StaffId)
        BEGIN
            SET @Message = N'Không tìm thấy nhân viên.';
            SET @Success = 0;
            RETURN;
        END

        -- Chỉ cho xóa khi đã Terminated
        IF EXISTS (SELECT 1 FROM dbo.staff WHERE id = @StaffId AND [status] <> 'Terminated')
        BEGIN
            SET @Message = N'Nhân viên chưa ở trạng thái Terminated. Không được xóa.';
            SET @Success = 0;
            RETURN;
        END

        BEGIN TRAN;

        -- Xóa dữ liệu phụ thuộc (nếu không dùng ON DELETE CASCADE)
        DELETE FROM dbo.contracts            WHERE staff_id = @StaffId;
        DELETE FROM dbo.qualifications       WHERE staff_id = @StaffId;
        DELETE FROM dbo.timesheets           WHERE staff_id = @StaffId;
        DELETE FROM dbo.performance_reviews  WHERE staff_id = @StaffId;

        -- Xóa nhân viên
        DELETE FROM dbo.staff WHERE id = @StaffId;

        COMMIT TRAN;

        SET @Success = 1;
        SET @Message = N'Xóa nhân viên thành công.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRAN;
        SET @Success = 0;
        SET @Message = ERROR_MESSAGE();
    END CATCH
END
GO