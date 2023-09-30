using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string Payment_Method { get; set; }

        [Range(1,double.MaxValue)]
        public double Total { get; set; }

        [ForeignKey("MovieShowId")]
        public int MovieShowId { get; set; }
        public MovieShow MovieShow { get; set; }

        [Range (1,5)] 
        [Required(ErrorMessage ="Not null")]
        public int SeatNumber { get; set; }
    }
}
