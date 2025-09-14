using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.data
{
    public class CourseDAO
    {
        public List<Course> GetCourse()
        {
            List<Course> courses = new List<Course>();

            // Mở kết nối
            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                string sql = "SELECT id, course_code, course_name, level, duration_sessions, base_fee, created_at FROM courses";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                Id = Guid.Parse(reader["id"].ToString()),
                                CourseCode = reader["course_code"].ToString(),
                                CourseName = reader["course_name"].ToString(),
                                Level = reader["level"].ToString(),
                                DurationSessions = Convert.ToInt32(reader["duration_sessions"]),
                                BaseFee = Convert.ToDecimal(reader["base_fee"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;
        }
    }
}
