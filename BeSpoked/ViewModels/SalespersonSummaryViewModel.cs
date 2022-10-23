using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class SalespersonSummaryViewModel
    {
        public int Sa_Rank { get; set; }
        public string Sp_Name { get; set; }
        public int Quarter { get; set; }
        public decimal Sa_Commission_Amt { get; set; }
        public decimal Sa_Amt { get; set; }
        public int Sa_Count { get; set; }
    }
}
