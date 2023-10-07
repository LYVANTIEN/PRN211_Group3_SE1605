using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{//xxxxxxxxxxxxxxxxx
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string MovieName { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string Genres { get; set; }

        [Range(0, double.MaxValue)]    
        public double Price { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string Image { get; set; }
        public int Rate { get; set; }
        public bool Upcoming { get; set; }
        public ICollection<MovieShow> MovieShows { get; set; }      


    }
}
