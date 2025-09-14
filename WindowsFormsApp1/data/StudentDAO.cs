using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.data
{
    public class StudentDAO
    {
        public StudentDAO() { }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            // Mở kết nối
            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();

                string sql = "SELECT id,student_code, full_name, phone, email, current_level, status, created_at, updated_at FROM students";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                Id = Guid.Parse(reader["id"].ToString()), 
                                StudentCode = reader["student_code"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Email = reader["email"].ToString(),
                                CurrentLevel = reader["current_level"].ToString(),
                                Status = reader["status"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }

        public Student findStudentByPhone(string phone)
        {
            Student student = null;

            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_FindStudentByPhone", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@phone", phone);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                Id = Guid.Parse(reader["id"].ToString()),
                                StudentCode = reader["student_code"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Email = reader["email"].ToString(),
                                CurrentLevel = reader["current_level"] != DBNull.Value
                                                ? reader["current_level"].ToString()
                                                : null
                            };
                        }
                    }
                }
            }

            return student;
        }
    }
}
