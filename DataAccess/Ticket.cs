using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public string Payment_Method { get; set; }

        public string? Total { get; set; }

        [ForeignKey("MovieShowId")]
        public int MovieShowId { get; set; }
        public MovieShow? MovieShow { get; set; }


        public int NumberSeat { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }        
    }
}
