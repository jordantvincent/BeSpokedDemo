using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class ProductViewModel
    {
        public int Pr_Key { get; set; }
        [Display(Name = "Name")]
        public string Pr_Name { get; set; }

        [Display(Name = "Manufacturer")]
        public string Pr_Manufacturer { get; set; }

        [Display(Name = "Style")]
        public string Pr_Style { get; set; }

        [Display(Name = "Purchase Cost")]
        public decimal Pr_Amt_Purchase { get; set; }

        [Display(Name = "Sale Price")]
        public decimal Pr_Amt_Sale { get; set; }

        [Display(Name = "Quantity")]
        public int Pr_Qty { get; set; }

        [Display(Name = "Commission")]
        public decimal Pr_Commission { get; set; }
    }
}
