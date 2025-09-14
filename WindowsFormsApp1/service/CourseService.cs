using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.service
{
    public class CourseService
    {
        private CourseDAO courseDAO = new CourseDAO();
        public List<Course> getAllCourses()
        {
            return courseDAO.GetCourse();
        }
       
    }
}
