using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("volunteer")]
    public class Volunteer
    {
        [Key]
        [Column("ID_Volunteer")]
        [Required]
        public int IDVolunteer { get; set; }

        [Column("First_Name")]
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        Country Country { get; set; }

        [Required]
        Gender Gender { get; set; }
    }
}
