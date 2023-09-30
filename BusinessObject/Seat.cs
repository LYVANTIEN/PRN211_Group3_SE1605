using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public int SeatNumber { get; set; }

        [Required(ErrorMessage ="Not null")]
        public bool Status { get; set; }

        [Required(ErrorMessage ="Not null")]

        [ForeignKey("TheaterHallId")]
        public int TheaterHallId { get; set; }
        public TheaterHall TheaterHall { get; set; } 

        public ICollection<Booking> Bookings { get; set; }  

    }
}
