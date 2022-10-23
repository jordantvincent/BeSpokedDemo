using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class SalesModel : TrackableModel
    {
        public SalesModel()
        {
            Sa_Date_Trans = DateTime.Today;
        }

        
        public int Sa_Key { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int Sa_Pr_Key { get; set; }

        [Required]
        [Display(Name = "Salesperson")]
        public int Sa_Sp_Key { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int Sa_Cu_Key { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime Sa_Date_Trans { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Sa_Qty { get; set; }

    }
}
