using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class TeachingAssignment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClassId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid? AssistantId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Today;

        [StringLength(20)]
        public string Status { get; set; } = "Assigned"; // Assigned, Active, Substituted, Cancelled

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Staff Teacher { get; set; }

        [ForeignKey("AssistantId")]
        public virtual Staff Assistant { get; set; }
    }
}
