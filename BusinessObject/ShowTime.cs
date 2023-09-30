using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ShowTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int TimeId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public TimeSpan Showtime { get; set; }  
        public ICollection<MovieShow> MovieShows { get; set; }  
    }
}
