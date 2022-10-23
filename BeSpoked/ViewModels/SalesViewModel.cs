using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class SalesViewModel
    {
        public int Sa_Key { get; set; }
        public string Pr_Name { get; set; }
        public string Cu_Name { get; set; }
        public string Sp_Name { get; set; }
        public DateTime Sa_Date_Trans { get; set; }
        public int Sa_Qty { get; set; }
        public decimal Sa_Amt { get; set; }
        public decimal Sa_Commission_Amt { get; set; }
        public decimal Sa_Commission_Percent { get; set; }
    }
}
