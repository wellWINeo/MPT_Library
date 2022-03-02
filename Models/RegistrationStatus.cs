using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("registration_status")]
    public class RegistrationStatus
    {
        [Key]
        [Column("ID_Registration_Status")]
        [Required]
        public int IDRegistrationStatus { get; set; }

        [Column("Status_Name")]
        [Required]
        [StringLength(80)]
        public string StatusName { get; set; }
    }
}
