using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Today;

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Test Entry, Pending, Active, Completed, Dropped, Cancelled

        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? FinalFee { get; set; }

        [StringLength(20)]
        public string PaymentPlan { get; set; } = "Full"; // Full, Installment

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

}
