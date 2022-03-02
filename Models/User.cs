using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("ID_User")]
        [Required]
        public int IDUser { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(100)]
        [Required]
        public string Password { get; set; }

        [Column("First_Name")]
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
