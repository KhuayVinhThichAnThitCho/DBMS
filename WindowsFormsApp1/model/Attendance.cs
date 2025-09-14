using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Attendance
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }

        public DateTime SessionDate { get; set; }
        public int SessionNumber { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Present"; // Present, Absent, Late, Excused

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
