using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("ID_Country")]
        [Required]
        public int IDCountry { get; set; }

        [Column("Country_Name")]
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        [Column("Country_Flag")]
        [Required]
        [StringLength(50)]
        public string CountryFlag { get; set; }

    }
}
