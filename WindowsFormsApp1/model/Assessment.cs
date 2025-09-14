using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.model
{
    public class Assessment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? HomeworkScore { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MidtermScore { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? FinalScore { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TotalScore { get; set; }

        [StringLength(20)]
        public string Result { get; set; } // Pass, Fail

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
