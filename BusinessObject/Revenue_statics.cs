using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Revenue_statics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int SaleId { get; set; }

        [Range(0,double.MaxValue)]
        public double TotalMoney { get; set; }

        [ForeignKey("TheaterId")]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }    
    }
}
