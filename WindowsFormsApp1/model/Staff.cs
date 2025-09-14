using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Staff
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string StaffCode { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Role { get; set; } // Teacher, Assistant, Counselor, Admin

        [StringLength(20)]
        public string EmploymentType { get; set; } // Full-time, Part-time, Freelancer

        [StringLength(20)]
        public string Status { get; set; } = "Onboarding"; // Onboarding, Active, Suspended, Terminated

        public DateTime? HireDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Class> ClassesAsTeacher { get; set; } = new List<Class>();
        public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
        public virtual ICollection<AssetCheckout> AssetCheckouts { get; set; } = new List<AssetCheckout>();
        public virtual ICollection<TeachingAssignment> TeachingAssignmentsAsTeacher { get; set; } = new List<TeachingAssignment>();
        public virtual ICollection<TeachingAssignment> TeachingAssignmentsAsAssistant { get; set; } = new List<TeachingAssignment>();
    }
}
