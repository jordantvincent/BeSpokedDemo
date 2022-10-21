using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class DiscountModel : TrackableModel
    {
        public int Ds_Key { get; set; }
        public int Ds_Pr_Key { get; set; }
        public DateTime Ds_Date_Beg { get; set; }
        public DateTime Ds_Date_Dend { get; set; }
    }
}
