using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1.model
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string CourseCode { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; }

        [StringLength(20)]
        public string Level { get; set; } // Beginner, Elementary, Intermediate, Advanced

        public int DurationSessions { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal BaseFee { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
