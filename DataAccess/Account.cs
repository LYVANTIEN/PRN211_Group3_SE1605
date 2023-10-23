using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Account
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int AccountId { get; set; }

  
      
        public string Username { get; set; }

        public string Password { get; set; }

        
        public string Email { get; set; }

        public string Phone { get; set; }


        [StringLength(6)]
        public string Role { get ; set; }

        public bool Baned { get; set; }
        public ICollection<Ticket>? tickets { get; set; }        

    }
}
