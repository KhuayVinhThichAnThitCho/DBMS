using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.model
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(20)]
        public string RoomCode { get; set; }

        [StringLength(50)]
        public string RoomName { get; set; }

        public int Capacity { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Available"; // Available, In-Use, Maintenance, Out-of-Service

        public string Facilities { get; set; } // JSON string

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
        public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
