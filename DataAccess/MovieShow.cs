using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MovieShow
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int MovieShowId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string? ShowTime { get; set; }
        public int MovieId { get; set; }
        
        [ForeignKey("TheaterHallId")]
        public int TheaterHallId { get; set; }
        public virtual Movie? Movies { get; set; }
        public virtual TheaterHall? TheaterHalls { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
