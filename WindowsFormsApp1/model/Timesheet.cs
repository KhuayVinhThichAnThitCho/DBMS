using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Timesheet
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StaffId { get; set; }

        public DateTime WorkDate { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal? HoursWorked { get; set; }

        [StringLength(20)]
        public string Type { get; set; } // Teaching, Administrative

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }

}
