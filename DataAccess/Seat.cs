using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }

        public int SeatNumber { get; set; }

        public string Status { get; set; }

        [ForeignKey("TheaterHallId")]
        public int TheaterHallId { get; set; }
        public virtual TheaterHall? TheaterHall { get; set; } 

        public ICollection<Booking>? Bookings { get; set; }


    }
}
