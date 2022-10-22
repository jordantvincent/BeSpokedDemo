﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class ProductModel : TrackableModel
    {
        public int Pr_Key { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Pr_Name { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public int Pr_Manufacturer { get; set; }

        [Required]
        [Display(Name = "Style")]
        public int Pr_Style { get; set; }

        [Required]
        [Display(Name = "Purchase Price")]
        public decimal Pr_Amt_Purchase { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        public decimal Pr_Amt_Sale { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Pr_Qty { get; set; }

        [Required]
        [Display(Name = "Commission")]
        public decimal Pr_Commission { get; set; }
    }
}
