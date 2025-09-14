using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1.model
{
    public class Invoice
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EnrollmentId { get; set; }

        [Required, StringLength(20)]
        public string InvoiceCode { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal FinalAmount { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Paid, Overdue, Cancelled

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("EnrollmentId")]
        public virtual Enrollment Enrollment { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

}
