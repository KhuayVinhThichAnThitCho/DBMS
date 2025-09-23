using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;

namespace WindowsFormsApp1.data.Staff
{
    class StaffDao
    {
        // Returns staff data from [AdminOps].[GetEmployeeInfo]
        public DataTable GetEmployeeInfo()
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[GetEmployeeInfo]", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var table = new DataTable();
                conn.Open();
                adapter.Fill(table);
                return table;
            }
        }

        // Add a new staff using stored procedure [AdminOps].[sp_AddStaff]
        public void AddStaff(
            string fullName,
            string role,
            string employmentType,
            string phone = null,
            string email = null,
            DateTime? hireDate = null,
            string contactInfo = null,
            string bankAccount = null,
            string taxCode = null)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_AddStaff]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", (object)fullName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", (object)role ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmploymentType", (object)employmentType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                if (hireDate.HasValue)
                    cmd.Parameters.AddWithValue("@HireDate", hireDate.Value);
                else
                    cmd.Parameters.AddWithValue("@HireDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@contact_info", (object)contactInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@bank_account", (object)bankAccount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tax_code", (object)taxCode ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Add a qualification using stored procedure [AdminOps].[sp_AddQualification]
        public void AddQualification(
            Guid staffId,
            string qualificationType,
            string issuingOrganization,
            decimal? score,
            DateTime issueDate,
            DateTime? expiryDate,
            bool isVerified)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_AddQualification]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@QualificationType", (object)qualificationType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IssuingOrganization", (object)issuingOrganization ?? DBNull.Value);
                if (score.HasValue)
                    cmd.Parameters.AddWithValue("@Score", score.Value);
                else
                    cmd.Parameters.AddWithValue("@Score", DBNull.Value);
                cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                if (expiryDate.HasValue)
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate.Value);
                else
                    cmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@IsVerified", isVerified);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Add a contract using stored procedure [Payroll].[sp_AddContract]
        public string AddContract(
            Guid staffId,
            string contractType,
            DateTime startDate,
            DateTime? endDate,
            string salaryModel,
            decimal? baseSalary,
            decimal? hourlyRate,
            decimal allowances,
            decimal bonusPolicy)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_AddContract]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@ContractType", (object)contractType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                if (endDate.HasValue)
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
                // Note: parameter name is @salarymodel in SP
                cmd.Parameters.AddWithValue("@salarymodel", (object)salaryModel ?? DBNull.Value);
                if (baseSalary.HasValue)
                    cmd.Parameters.AddWithValue("@BaseSalary", baseSalary.Value);
                else
                    cmd.Parameters.AddWithValue("@BaseSalary", DBNull.Value);
                if (hourlyRate.HasValue)
                    cmd.Parameters.AddWithValue("@HourlyRate", hourlyRate.Value);
                else
                    cmd.Parameters.AddWithValue("@HourlyRate", DBNull.Value);
                cmd.Parameters.AddWithValue("@Allowances", allowances);
                cmd.Parameters.AddWithValue("@BonusPolicy", bonusPolicy);

                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // SELECT: Staff + Qualifications + Contracts for a staff
        public DataSet GetStaffAllById(Guid staffId)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_GetStaffAllById]", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staffId);

                var ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                if (ds.Tables.Count > 0) ds.Tables[0].TableName = "Staff";
                if (ds.Tables.Count > 1) ds.Tables[1].TableName = "Qualifications";
                if (ds.Tables.Count > 2) ds.Tables[2].TableName = "Contracts";
                return ds;
            }
        }

        // UPDATE: Staff
        public void UpdateStaff(
            Guid staffId,
            string fullName = null,
            string role = null,
            string employmentType = null,
            string phone = null,
            string email = null,
            DateTime? hireDate = null,
            DateTime? terminationDate = null,
            string contactInfo = null,
            string bankAccount = null,
            string taxCode = null,
            string status = null)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_UpdateStaff]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@FullName", (object)fullName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", (object)role ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmploymentType", (object)employmentType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HireDate", (object)hireDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TerminationDate", (object)terminationDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@contact_info", (object)contactInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@bank_account", (object)bankAccount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tax_code", (object)taxCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", (object)status ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE: Qualification
        public void UpdateQualification(
            Guid qualificationId,
            string qualificationType = null,
            string issuingOrganization = null,
            decimal? score = null,
            DateTime? issueDate = null,
            DateTime? expiryDate = null,
            bool? isVerified = null)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_UpdateQualification]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QualificationId", qualificationId);
                cmd.Parameters.AddWithValue("@QualificationType", (object)qualificationType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IssuingOrganization", (object)issuingOrganization ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Score", (object)score ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IssueDate", (object)issueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExpiryDate", (object)expiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsVerified", (object)isVerified ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE: Contract
        public string UpdateContract(
            Guid contractId,
            Guid? staffId = null,
            string contractType = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string salaryModel = null,
            decimal? baseSalary = null,
            decimal? hourlyRate = null,
            decimal? allowances = null,
            decimal? bonusPolicy = null)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_UpdateContract]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContractId", contractId);
                cmd.Parameters.AddWithValue("@StaffId", (object)staffId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ContractType", (object)contractType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartDate", (object)startDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EndDate", (object)endDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SalaryModel", (object)salaryModel ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BaseSalary", (object)baseSalary ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HourlyRate", (object)hourlyRate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Allowances", (object)allowances ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BonusPolicy", (object)bonusPolicy ?? DBNull.Value);

                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // Delete Qualification
        public string DeleteQualification(Guid qualificationId)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_DeleteQualification]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QualificationId", qualificationId);
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // Delete Contract (Option 2 logic implemented in SP)
        public string DeleteContract(Guid contractId)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_DeleteContract]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContractId", contractId);
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // Get timesheets by staff and optional period
        public DataTable GetTimesheetsByStaff(Guid staffId, DateTime? startDate = null, DateTime? endDate = null)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_GetTimesheetsByStaff]", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                var pStart = new SqlParameter("@StartDate", SqlDbType.Date) { Value = (object)startDate ?? DBNull.Value };
                var pEnd = new SqlParameter("@EndDate", SqlDbType.Date) { Value = (object)endDate ?? DBNull.Value };
                cmd.Parameters.Add(pStart);
                cmd.Parameters.Add(pEnd);

                var dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        // Approve a timesheet
        public string ApproveTimesheet(Guid timesheetId, string approvedBy)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_ApproveTimesheet]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TimesheetId", timesheetId);
                cmd.Parameters.AddWithValue("@ApprovedBy", (object)approvedBy ?? DBNull.Value);
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // Generate payroll for a period
        public DataTable GeneratePayroll(DateTime periodStart, DateTime periodEnd)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_GeneratePayroll]", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PeriodStart", periodStart);
                cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd);

                var dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public void UpsertMonthlyTotals(int year, int month)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_UpsertMonthlyTotals]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetMonthlySalary(int year, int month, Guid staffId)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_GetMonthlySalary]", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                var dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public string AddMonthlyDisbursement(Guid staffId, int year, int month, decimal amount)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[Payroll].[sp_AddMonthlyDisbursement]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Amount", amount);
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(messageParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                return messageParam.Value?.ToString();
            }
        }

        // Delete Staff If Terminated
        public string DeleteStaffIfTerminated(Guid staffId, out bool success)
        {
            using (SqlConnection conn = DBConnection.getConnection())
            using (SqlCommand cmd = new SqlCommand("[AdminOps].[sp_DeleteStaffIfTerminated]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffId", staffId);

                var msgParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                var successParam = new SqlParameter("@Success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(msgParam);
                cmd.Parameters.Add(successParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                success = successParam.Value != DBNull.Value && Convert.ToBoolean(successParam.Value);
                return msgParam.Value?.ToString();
            }
        }
    }
}
