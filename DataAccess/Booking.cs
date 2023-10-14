using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int BookingId { get; set; }

        public TimeSpan Time { get; set; }

        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }  
    }
}
