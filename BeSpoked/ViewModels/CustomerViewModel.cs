using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class CustomerViewModel
    {
        public int Cu_Key { get; set; }
        public string Cu_Name { get; set; }
        public string Cu_Name_First { get; set; }
        public string Cu_Name_Last { get; set; }
        public string Cu_Name_FL { get; set; }
        public string Cu_Addr_1 { get; set; }
        public string Cu_Addr_2 { get; set; }
        public string Cu_Phone { get; set; }
        public DateTime Cu_Date_Start { get; set; }
    }
}
