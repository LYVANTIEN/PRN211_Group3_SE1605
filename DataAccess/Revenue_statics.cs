using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Revenue_statics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int SaleId { get; set; }

        public string?   TotalMoney { get; set; }

        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }
        public virtual Theater? Theater { get; set; }    
    }
}
