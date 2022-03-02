using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("event")]
    public class Event
    {
        [Key]
        [Column("ID_Event")]
        [Required]
        public int IDEvent { get; set; }


        [Column("Event_Name")]
        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Required]
        public Race Race { get; set; }

        [Required]
        public DateOnly StartDateTime { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

    }
}
