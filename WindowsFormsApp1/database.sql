-- =====================================================
-- THIẾT KẾ CÁC BẢNG - HỆ THỐNG QUẢN LÝ TRUNG TÂM ANH NGỮ
-- =====================================================

-- 1. QUẢN LÝ HỌC VIÊN
-- =====================================================
-- Học viên
CREATE TABLE students (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    student_code NVARCHAR(20) UNIQUE NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(15),
    email NVARCHAR(100),
    current_level NVARCHAR(20) CHECK (current_level IN ('Beginner', 'Elementary', 'Intermediate', 'Advanced')),
    status NVARCHAR(20) CHECK (status IN ('Prospect', 'Active', 'Inactive', 'Graduated')) DEFAULT 'Prospect',
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

-- Trigger để cập nhật updated_at
CREATE TRIGGER tr_students_update
ON students
AFTER UPDATE
AS
BEGIN
    UPDATE students
    SET updated_at = GETDATE()
    FROM students
    INNER JOIN inserted ON students.id = inserted.id;
END;

-- Khóa học
CREATE TABLE courses (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    course_code NVARCHAR(20) UNIQUE NOT NULL,
    course_name NVARCHAR(100) NOT NULL,
    level NVARCHAR(20) CHECK (level IN ('Beginner', 'Elementary', 'Intermediate', 'Advanced')),
    duration_sessions INT NOT NULL,
    base_fee DECIMAL(10,2) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

-- Lớp học
CREATE TABLE classes (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    class_code NVARCHAR(20) UNIQUE NOT NULL,
    course_id UNIQUEIDENTIFIER NOT NULL,
    teacher_id UNIQUEIDENTIFIER,
    room_id UNIQUEIDENTIFIER,
    max_capacity INT DEFAULT 15,
    schedule NVARCHAR(MAX), -- Lưu JSON dạng chuỗi: {"days": ["Monday", "Wednesday"], "time": "18:00-20:00"}
    start_date DATE,
    end_date DATE,
    status NVARCHAR(20) CHECK (status IN ('Planned', 'Open', 'Active', 'Completed', 'Cancelled')) DEFAULT 'Planned',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (course_id) REFERENCES courses(id),
    FOREIGN KEY (teacher_id) REFERENCES staff(id),
    FOREIGN KEY (room_id) REFERENCES rooms(id)
);

-- Ghi danh
CREATE TABLE enrollments (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    student_id UNIQUEIDENTIFIER NOT NULL,
    class_id UNIQUEIDENTIFIER NOT NULL,
    enrollment_date DATE DEFAULT GETDATE(),
    status NVARCHAR(20) CHECK (status IN ('Pending', 'Active', 'Completed', 'Dropped', 'Cancelled')) DEFAULT 'Pending',
    total_fee DECIMAL(10,2),
    discount_amount DECIMAL(10,2) DEFAULT 0,
    final_fee DECIMAL(10,2),
    payment_plan NVARCHAR(20) CHECK (payment_plan IN ('Full', 'Installment')) DEFAULT 'Full',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (student_id) REFERENCES students(id),
    FOREIGN KEY (class_id) REFERENCES classes(id)
);
ALTER TABLE enrollments
ADD entry_test_status NVARCHAR(20) 
    CHECK (entry_test_status IN ('Not Required', 'Pending', 'Passed', 'Failed')) 
    DEFAULT 'Not Required';


-- Điểm danh
CREATE TABLE attendance (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    class_id UNIQUEIDENTIFIER NOT NULL,
    student_id UNIQUEIDENTIFIER NOT NULL,
    session_date DATE NOT NULL,
    session_number INT NOT NULL,
    status NVARCHAR(20) CHECK (status IN ('Present', 'Absent', 'Late', 'Excused')) DEFAULT 'Present',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (class_id) REFERENCES classes(id),
    FOREIGN KEY (student_id) REFERENCES students(id)
);

-- Đánh giá
CREATE TABLE assessments (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    class_id UNIQUEIDENTIFIER NOT NULL,
    student_id UNIQUEIDENTIFIER NOT NULL,
    homework_score DECIMAL(5,2),
    midterm_score DECIMAL(5,2),
    final_score DECIMAL(5,2),
    total_score DECIMAL(5,2),
    result NVARCHAR(20) CHECK (result IN ('Pass', 'Fail')),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (class_id) REFERENCES classes(id),
    FOREIGN KEY (student_id) REFERENCES students(id)
);

-- =====================================================
-- 2. QUẢN LÝ TÀI CHÍNH
-- =====================================================
-- Hóa đơn
CREATE TABLE invoices (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    enrollment_id UNIQUEIDENTIFIER NOT NULL,
    invoice_code NVARCHAR(20) UNIQUE NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    discount DECIMAL(10,2) DEFAULT 0,
    final_amount DECIMAL(10,2) NOT NULL,
    due_date DATE,
    status NVARCHAR(20) CHECK (status IN ('Pending', 'Paid', 'Overdue', 'Cancelled')) DEFAULT 'Pending',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (enrollment_id) REFERENCES enrollments(id)
);

-- Thanh toán
CREATE TABLE payments (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    invoice_id UNIQUEIDENTIFIER NOT NULL,
    payment_code NVARCHAR(20) UNIQUE NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    payment_method NVARCHAR(20) CHECK (payment_method IN ('Cash', 'Transfer', 'Card', 'QR')) DEFAULT 'Cash',
    payment_date DATE DEFAULT GETDATE(),
    installment_number INT DEFAULT 1,
    notes NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (invoice_id) REFERENCES invoices(id)
);

-- =====================================================
-- 3. QUẢN LÝ NHÂN VIÊN
-- =====================================================
-- Nhân viên
CREATE TABLE staff (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    staff_code NVARCHAR(20) UNIQUE NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(15),
    email NVARCHAR(100),
    role NVARCHAR(20) CHECK (role IN ('Teacher', 'Assistant', 'Counselor', 'Admin')),
    employment_type NVARCHAR(20) CHECK (employment_type IN ('Full-time', 'Part-time', 'Freelancer')),
    status NVARCHAR(20) CHECK (status IN ('Onboarding', 'Active', 'Suspended', 'Terminated')) DEFAULT 'Onboarding',
    hire_date DATE,
    created_at DATETIME DEFAULT GETDATE()
);

-- Chứng chỉ nhân viên
CREATE TABLE qualifications (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    staff_id UNIQUEIDENTIFIER NOT NULL,
    qualification_type NVARCHAR(50),
    issuing_organization NVARCHAR(100),
    issue_date DATE,
    expiry_date DATE,
    is_verified BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (staff_id) REFERENCES staff(id)
);

-- Chấm công
CREATE TABLE timesheets (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    staff_id UNIQUEIDENTIFIER NOT NULL,
    work_date DATE NOT NULL,
    hours_worked DECIMAL(4,2),
    type NVARCHAR(20) CHECK (type IN ('Teaching', 'Administrative')),
    status NVARCHAR(20) CHECK (status IN ('Pending', 'Approved', 'Rejected')) DEFAULT 'Pending',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (staff_id) REFERENCES staff(id)
);

-- =====================================================
-- 4. QUẢN LÝ PHÒNG HỌC & THIẾT BỊ
-- =====================================================
-- Phòng học
CREATE TABLE rooms (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    room_code NVARCHAR(20) UNIQUE NOT NULL,
    room_name NVARCHAR(50),
    capacity INT NOT NULL,
    status NVARCHAR(20) CHECK (status IN ('Available', 'In-Use', 'Maintenance', 'Out-of-Service')) DEFAULT 'Available',
    facilities NVARCHAR(MAX), -- Lưu JSON dạng chuỗi: ["projector", "whiteboard", "air-conditioner"]
    created_at DATETIME DEFAULT GETDATE()
);

-- Thiết bị
CREATE TABLE assets (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    asset_code NVARCHAR(20) UNIQUE NOT NULL,
    asset_name NVARCHAR(100) NOT NULL,
    category NVARCHAR(50),
    current_room_id UNIQUEIDENTIFIER,
    status NVARCHAR(20) CHECK (status IN ('Available', 'In-Use', 'Maintenance', 'Out-of-Service')) DEFAULT 'Available',
    purchase_date DATE,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (current_room_id) REFERENCES rooms(id)
);

-- Mượn thiết bị
CREATE TABLE asset_checkouts (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    asset_id UNIQUEIDENTIFIER NOT NULL,
    borrower_id UNIQUEIDENTIFIER NOT NULL,
    checkout_date DATE NOT NULL,
    expected_return_date DATE NOT NULL,
    actual_return_date DATE,
    status NVARCHAR(20) CHECK (status IN ('Active', 'Returned', 'Overdue')) DEFAULT 'Active',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (asset_id) REFERENCES assets(id),
    FOREIGN KEY (borrower_id) REFERENCES staff(id)
);

-- =====================================================
-- 5. BẢNG PHỤ TRỢ
-- =====================================================
-- Lịch học chi tiết
CREATE TABLE schedules (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    class_id UNIQUEIDENTIFIER NOT NULL,
    session_number INT NOT NULL,
    session_date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    room_id UNIQUEIDENTIFIER,
    status NVARCHAR(20) CHECK (status IN ('Scheduled', 'Completed', 'Cancelled', 'Rescheduled')) DEFAULT 'Scheduled',
    notes NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (class_id) REFERENCES classes(id),
    FOREIGN KEY (room_id) REFERENCES rooms(id)
);

-- Phân công giảng dạy
CREATE TABLE teaching_assignments (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    class_id UNIQUEIDENTIFIER NOT NULL,
    teacher_id UNIQUEIDENTIFIER NOT NULL,
    assistant_id UNIQUEIDENTIFIER,
    assigned_date DATE DEFAULT GETDATE(),
    status NVARCHAR(20) CHECK (status IN ('Assigned', 'Active', 'Substituted', 'Cancelled')) DEFAULT 'Assigned',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (class_id) REFERENCES classes(id),
    FOREIGN KEY (teacher_id) REFERENCES staff(id),
    FOREIGN KEY (assistant_id) REFERENCES staff(id)
);