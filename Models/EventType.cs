using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("event_type")]
    public class EventType
    {

        [Key]
        [Column("ID_Event_type")]
        [Required]
        public int IDEventType { get; set; }

        [Column("Event_Type_Name")]
        [Required]
        [StringLength(80)]
        public string EventTypeName { get; set; }


    }
}
