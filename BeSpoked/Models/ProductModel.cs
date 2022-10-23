using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class ProductModel : TrackableModel
    {
        public int Pr_Key { get; set; }
        [Required(ErrorMessage = "This value is required")]
        [Display(Name ="Name")]
        [MaxLength(75)]
        public string Pr_Name { get; set; }

        [Required(ErrorMessage = "Please select one")]
        [Display(Name = "Manufacturer")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an option")]
        public int Pr_Manufacturer { get; set; }

        [Required]
        [Display(Name = "Style")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an option")]
        public int Pr_Style { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Must be greater than $0.00")]
        [Display(Name = "Purchase Price")]
        public decimal Pr_Amt_Purchase { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Must be greater than $0.00")]
        [Display(Name = "Sale Price")]
        public decimal Pr_Amt_Sale { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater")]
        [Display(Name = "Quantity")]
        public int Pr_Qty { get; set; }

        [Required]
        [Range(0, 1.0, ErrorMessage = "Must be between 0 and 1")]
        [Display(Name = "Commission")]
        public decimal Pr_Commission { get; set; }
    }
}
