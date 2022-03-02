using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("staff")]
    public class Staff
    {
        [Key]
        [Required]
        public int IDStaff { get; set; }

        [StringLength(80)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(80)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        Gender Gender { get; set; }

        [Required]
        Position Position { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(200)]
        [Required]
        public string Comments { get; set; }
    }
}
