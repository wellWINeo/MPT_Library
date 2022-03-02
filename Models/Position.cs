using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("position")]
    public class Position
    {
        [Key]
        [Required]
        public int IDPosition { get; set; }

        [StringLength(100)]
        [Required]
        public string PositionName { get; set; }
        [StringLength(200)]
        public string PositionDescription { get; set; }

        [StringLength(10)]
        [Required]
        public string PayPeriod { get; set; }

        [Required]
        public int PayRate { get; set; }
    }
}
