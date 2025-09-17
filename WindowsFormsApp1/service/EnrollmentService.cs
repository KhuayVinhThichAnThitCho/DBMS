using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.data;

namespace WindowsFormsApp1.service
{
    public class EnrollmentService
    {
        private EnrollmentDAO enrollmentDAO = new EnrollmentDAO();
        public (bool Success, string Message) handleEnrollment(Guid id, Guid classId)
        {
             return enrollmentDAO.handleEnrollment(id,classId);

        }
    }
}
