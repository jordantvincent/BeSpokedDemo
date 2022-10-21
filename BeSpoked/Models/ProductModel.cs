using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class ProductModel : TrackableModel
    {
        public int Pr_Key { get; set; }
        public int Pr_Name { get; set; }
        public int Pr_Manufacturer { get; set; }
        public int Pr_Style { get; set; }
        public decimal Pr_Amt_Purchase { get; set; }
        public decimal Pr_Amt_Sale { get; set; }
        public int Pr_Qty { get; set; }
        public decimal Pr_Discount { get; set; }
    }
}
