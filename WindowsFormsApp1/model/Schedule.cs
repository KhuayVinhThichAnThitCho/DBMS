using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.model
{
    public class Schedule
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClassId { get; set; }

        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Guid? RoomId { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled, Rescheduled

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
