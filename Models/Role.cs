using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("role")]
    public class Role
    {
        [Key]
        [Column("ID_Role")]
        [Required]
        public int IDRole { get; set; }

        [Column("Role_Name")]
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
