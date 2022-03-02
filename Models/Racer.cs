using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("racer")]
    public class Racer
    {
        [Key]
        [Column("IDRacer")]
        [Required]
        public int ID_Racer { get; set; }

        [Column("First_Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public virtual Country Country { get; set; }
    }
}
