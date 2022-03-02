using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("charity")]
    public class Charity
    {
        [Key]
        [Column("ID_Сharity")]
        [Required]
        public int IDСharity { get; set; }

        [Column("Charity_Name")]
        [Required]
        [StringLength(100)]
        public string CharityName { get; set; }

        [Column("Charity_Description")]
        public string CharityDescription { get; set; }

        [Column("Charity_Logo")]
        [StringLength(50)]
        public string CharityLogo { get; set; }
    }
}
