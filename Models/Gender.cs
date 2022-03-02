using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("gender")]
    public class Gender
    {
        [Key]
        [Column("ID_Gender")]
        [Required]
        public int IDGender { get; set; }

        [Column("Gender_Name")]
        [Required]
        [StringLength(50)]
        public string GenderName { get; set; }
    }
}
