using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class EmployeeModel : TrackableModel
    {
        public int Em_Key { get; set; }
        public string Em_Name_First { get; set; }
        public string Em_Name_Last { get; set; }
        public string Em_Name_FL { get; set; }
        public string Em_Addr_1 { get; set; }
        public string Em_Addr_2 { get; set; }
        public string Em_Addr_3 { get; set; }
        public string Em_Addr_4 { get; set; }
        public string Em_Phone { get; set; }
        public DateTime Em_Date_Start { get; set; }
        public DateTime Em_Date_Termination { get; set; }
        public int Em_Dept_Key { get; set; }
    }
}
