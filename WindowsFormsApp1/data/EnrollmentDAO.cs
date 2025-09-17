using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.model;
using System.Windows.Forms;

namespace WindowsFormsApp1.data
{
    public class EnrollmentDAO
    {
        public (bool Success, string Message) handleEnrollment(Guid studentId,Guid classId)
        {

            try
            {
                using (SqlConnection conn = DBConnection.getConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO enrollments (student_id, class_id)
                               VALUES (@student_id, @class_id)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        cmd.Parameters.AddWithValue("@class_id", classId);

                        cmd.ExecuteNonQuery();
                    }
                }
                return (true, "Đăng ký thành công!");
            }
            catch (SqlException ex)
            {
                return (false, "Lỗi đăng ký: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi hệ thống: " + ex.Message);
            }
        }
    }
    }
