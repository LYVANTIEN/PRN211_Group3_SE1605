using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int BookingId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public TimeSpan Time { get; set; }

        [ForeignKey("SeatId")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }  
    }
}
