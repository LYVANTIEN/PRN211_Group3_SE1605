using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{//xxxxxxxxxxxxxxxxx
    public class Movie
    {//new from tiendev aaa
        public Movie()
        {
            this.MovieShows = new HashSet<MovieShow>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Description { get; set; }


        public string Genres { get; set; }

       
        public string Price { get; set; }

        public string Image { get; set; }
        public int Rate { get; set; }
        public string Upcoming { get; set; }
        public ICollection<MovieShow> MovieShows { get; set; }       


    }
}
