using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Theater
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int TheaterId { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string TheaterName { get; set; }

        [Required(ErrorMessage ="Not null")]
        public int NumberTheateHall { get; set; }

        [Required(ErrorMessage ="Not null")]
        public string Address { get; set; }

        public ICollection<TheaterHall> theaterHalls { get; set; }  
        public ICollection<Revenue_statics> revenue_statics { get; set; }
    }
}
