using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MovieShow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int MovieShowId { get; set; }

        [ForeignKey("TimeId")]
        public int TimeId { get; set; }
        
        public ShowTime ShowTimes { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movies { get; set; }

        [ForeignKey("TheaterHallId")]
        public int TheaterHallId { get; set; }
        public TheaterHall TheaterHalls { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
