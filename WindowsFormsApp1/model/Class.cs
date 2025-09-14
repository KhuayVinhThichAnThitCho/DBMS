using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string ClassCode { get; set; }

        public Guid CourseId { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? RoomId { get; set; }

        public int CurrentCapacity { get;set; } = 0;
        public int MaxCapacity { get; set; } = 15;

        public string Schedule { get; set; } // JSON string

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planned"; // Planned, Open, Active, Completed, Cancelled

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Staff Teacher { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public virtual ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    }

}
