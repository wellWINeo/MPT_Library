using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("result")]
    public class Result
    {
        [Key]
        [Column("ID_Result")]
        [Required]
        public int IDResult { get; set; }

        [Required]
        public Registration Registration { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public int BidNumber { get; set; }

        [Required]
        public TimeOnly RaceTime { get; set; }

    }
}
