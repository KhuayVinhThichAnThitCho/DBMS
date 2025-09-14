using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1.model
{
    public class Qualification
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StaffId { get; set; }

        [StringLength(50)]
        public string QualificationType { get; set; }

        [StringLength(100)]
        public string IssuingOrganization { get; set; }

        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public bool IsVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }

}
