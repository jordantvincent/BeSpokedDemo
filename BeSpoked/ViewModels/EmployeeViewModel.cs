using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class EmployeeViewModel
    {
        public int Em_Key { get; set; }
        public string Em_Name_First { get; set; }
        public string Em_Name_Last { get; set; }
        public DateTime Em_Date_Started { get; set; }
        public string Dm_Name { get; set; }
    }
}
