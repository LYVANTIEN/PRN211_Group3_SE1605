﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TheaterHall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheaterHallId { get; set; }
        [Required(ErrorMessage ="Not null")]
        public string TheaterName { get; set; }
        [Required(ErrorMessage ="Not null")]
        public int NumberOfSeats { get; set; }

        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }    

        public ICollection<Seat> Seats { get; set; }
        public ICollection<MovieShow> MovieShows { get; set; }  
    }
}
