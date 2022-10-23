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
        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer")]
        public int Sa_Pr_Key { get; set; }

        [Required]
        [Display(Name = "Salesperson")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a product")]
        public int Sa_Sp_Key { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a salesperson")]
        public int Sa_Cu_Key { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime Sa_Date_Trans { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Sa_Qty { get; set; }

    }
}
