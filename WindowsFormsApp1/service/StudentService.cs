using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.service
{
    public class StudentService
    {
        private  StudentDAO studentDAO = new StudentDAO();
        public List<Student> getAllStudents()
        {
            return studentDAO.GetStudents();
        }
    }
}
