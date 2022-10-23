using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class EmployeeViewModel
    {
        public int Em_Key { get; set; }
        [Display(Name="First Name")]
        public string Em_Name_First { get; set; }

        [Display(Name = "Last Name")]
        public string Em_Name_Last { get; set; }

        [Display(Name = "Address Line 1")]
        public string Em_Addr_1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Em_Addr_2 { get; set; }

        [Display(Name = "Start Date")]
        public DateTime Em_Date_Start { get; set; }

        [Display(Name = "Manager")]
        public string Em_Mg_Name { get; set; }

        [Display(Name = "Phone Number")]
        public string Em_Phone { get; set; }

        [Display(Name = "Termination Date")]
        public DateTime Em_Date_Terminated { get; set; }

        [Display(Name = "Active")]
        public bool Em_Active { get; set; }
    }
}
