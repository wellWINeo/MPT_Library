using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("sponsorship")]
    public class Sponsorship
    {
        [Key]
        [Column("ID_Sponsorship")]
        [Required]
        public int IDSponsorship { get; set; }

        [StringLength(150)]
        [Required]
        public string SponsorName { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
