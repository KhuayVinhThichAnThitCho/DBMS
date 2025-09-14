using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Asset
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string AssetCode { get; set; }

        [Required, StringLength(100)]
        public string AssetName { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public Guid? CurrentRoomId { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Available"; // Available, In-Use, Maintenance, Out-of-Service

        public DateTime? PurchaseDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CurrentRoomId")]
        public virtual Room CurrentRoom { get; set; }

        public virtual ICollection<AssetCheckout> AssetCheckouts { get; set; } = new List<AssetCheckout>();
    }
}
