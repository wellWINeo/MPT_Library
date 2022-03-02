using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("timesheet")]
    public class Timesheet
    {
        [Key]
        [Required]
        public int IDTimesheet { get; set; }

        [Required]
        public Staff Staff { get; set; }

        public DateOnly StartDateTime { get; set; }

        public DateOnly EndDateTime { get; set; }

        public decimal PayAmount { get; set; }




    }
}
