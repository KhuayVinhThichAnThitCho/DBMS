using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1.model
{
    public class AssetCheckout
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AssetId { get; set; }
        public Guid BorrowerId { get; set; }

        public DateTime CheckoutDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Active"; // Active, Returned, Overdue

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

        [ForeignKey("BorrowerId")]
        public virtual Staff Borrower { get; set; }
    }
}
