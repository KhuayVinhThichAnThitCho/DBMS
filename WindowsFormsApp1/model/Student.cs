using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.model
{
    public class Student
    {
        private Guid id = Guid.NewGuid();
        private string studentCode;
        private string fullName;
        private string phone;
        private string email;
        private string currentLevel = "Beginner";
        private string status = "Prospect";
        private DateTime createdAt = DateTime.Now;
        private DateTime updatedAt = DateTime.Now;

        // Getter & Setter
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string StudentCode
        {
            get { return studentCode; }
            set { studentCode = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        // Default constructor
        public Student() { }

        // Constructor with parameters
        public Student(string studentCode, string fullName, string phone = null, string email = null, string currentLevel = "Beginner", string status = "Prospect")
        {
            StudentCode = studentCode;
            FullName = fullName;
            Phone = phone;
            Email = email;
            CurrentLevel = currentLevel;
            Status = status;
        }

        
    }
}
