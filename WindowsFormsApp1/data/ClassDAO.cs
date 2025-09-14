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
    public class ClassDAO
    {
        public List<Class> FindClassByCourseId(Guid Id)
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_FindClassByCourseCode", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseCode", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Class classItem = new Class
                            {
                                Id = Guid.Parse(reader["class_id"].ToString()),
                                ClassCode = reader["class_code"].ToString(),
                                CourseId = Guid.Parse(reader["course_id"].ToString()),
                                TeacherId = reader["teacher_id"] != DBNull.Value
                                            ? Guid.Parse(reader["teacher_id"].ToString())
                                            : (Guid?)null,
                                RoomId = reader["room_id"] != DBNull.Value
                                         ? Guid.Parse(reader["room_id"].ToString())
                                         : (Guid?)null,
                                CurrentCapacity = Convert.ToInt32(reader["current_capacity"]),
                                MaxCapacity = Convert.ToInt32(reader["max_capacity"]),
                                Schedule = reader["schedule"]?.ToString(),
                                StartDate = reader["start_date"] != DBNull.Value
                                            ? Convert.ToDateTime(reader["start_date"])
                                            : (DateTime?)null,
                                EndDate = reader["end_date"] != DBNull.Value
                                          ? Convert.ToDateTime(reader["end_date"])
                                          : (DateTime?)null,
                                Status = reader["status"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["class_created_at"])
                            };

                            classes.Add(classItem);
                        }
                    }
                }
            }

            return classes;
        }

        public List<Class> FindAvailbaleClassByCourseId(Guid Id)
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_FindAvailableByCourseCode", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseCode", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Class classItem = new Class
                            {
                                Id = Guid.Parse(reader["class_id"].ToString()),
                                ClassCode = reader["class_code"].ToString(),
                                CourseId = Guid.Parse(reader["course_id"].ToString()),
                                TeacherId = reader["teacher_id"] != DBNull.Value
                                            ? Guid.Parse(reader["teacher_id"].ToString())
                                            : (Guid?)null,
                                RoomId = reader["room_id"] != DBNull.Value
                                         ? Guid.Parse(reader["room_id"].ToString())
                                         : (Guid?)null,
                                CurrentCapacity = Convert.ToInt32(reader["current_capacity"]),
                                MaxCapacity = Convert.ToInt32(reader["max_capacity"]),
                                Schedule = reader["schedule"]?.ToString(),
                                StartDate = reader["start_date"] != DBNull.Value
                                            ? Convert.ToDateTime(reader["start_date"])
                                            : (DateTime?)null,
                                EndDate = reader["end_date"] != DBNull.Value
                                          ? Convert.ToDateTime(reader["end_date"])
                                          : (DateTime?)null,
                                Status = reader["status"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["class_created_at"])
                            };

                            classes.Add(classItem);
                        }
                    }
                }
            }

            return classes;
        }
    }
}
