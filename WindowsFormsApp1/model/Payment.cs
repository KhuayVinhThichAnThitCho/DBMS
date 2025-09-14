using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid InvoiceId { get; set; }

        [Required, StringLength(20)]
        public string PaymentCode { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [StringLength(20)]
        public string PaymentMethod { get; set; } = "Cash"; // Cash, Transfer, Card, QR

        public DateTime PaymentDate { get; set; } = DateTime.Today;

        public int InstallmentNumber { get; set; } = 1;

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
