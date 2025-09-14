using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.data;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.service
{
    public class ClassService
    {
        private ClassDAO classDAO = new ClassDAO();
        public List<Class> GetAllClasses(Guid code)
        {
            return classDAO.FindClassByCourseId(code);
        }
        public List<Class> getAvailableClass(Guid code)
        {
            return classDAO.FindAvailbaleClassByCourseId(code);
        }
    }
}
