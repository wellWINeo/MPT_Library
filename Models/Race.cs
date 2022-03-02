using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("race")]
    public class Race
    {
        [Key]
        [Column("ID_Race")]
        [Required]
        public int IDRace { get; set; }

        [Column("Race_Name")]
        [Required]
        [StringLength(80)]
        public string RaceName { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [Required]
        public Country County { get; set; }

        [Column("Year_Held")]
        [Required]
        public int YearHeld { get; set; }
    }
}
