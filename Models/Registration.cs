using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("registration")]
    public class Registration
    {
        [Key]
        [Column("ID_Registration")]
        [Required]
        public int IDRegistration { get; set; }

        [Required]
        public Racer Racer { get; set; }

        [Column("Registration_Date")]
        [Required]
        public DateOnly RegistrationDate { get; set; }

        [Required]
        RegistrationStatus RegistrationStatus { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public Charity Charity { get; set; }

        [Required]
        public decimal SponsorshipTarget { get; set; }

    }
}
