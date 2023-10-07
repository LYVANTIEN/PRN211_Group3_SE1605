using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Account
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int AccountId { get; set; }

        
        [Required (ErrorMessage ="Not null")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Not null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address."), StringLength(50)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Not null")]
        [DataType (DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }


        [StringLength(6)]
        public string Role { get ; set; }

        public bool Baned { get; set; }
        public ICollection<Ticket> tickets { get; set; }        

    }
}
