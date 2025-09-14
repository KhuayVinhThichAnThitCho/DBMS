using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string StudentCode { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string CurrentLevel { get; set; } // Beginner, Elementary, Intermediate, Advanced

        [StringLength(20)]
        public string Status { get; set; } = "Prospect"; // Prospect, Active, Inactive, Graduated

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}
