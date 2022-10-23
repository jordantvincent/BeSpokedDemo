using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.ViewModels
{
    public class SalespersonViewModel
    {
        public int Sp_Key { get; set; }

        [Display(Name = "First Name")]
        public string Sp_Name_First { get; set; }

        [Display(Name = "Last Name")]
        public string Sp_Name_Last { get; set; }

        public string Sp_Name { get; set; }
        public string Sp_Name_FL { get; set; }

        [Display(Name = "Address Line 1")]
        public string Sp_Addr_1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Sp_Addr_2 { get; set; }


        [Display(Name = "Phone Number")]
        public string Sp_Phone { get; set; }

        [Display(Name = "Start Date")]
        public DateTime Sp_Date_Start { get; set; }
        public DateTime Sp_Date_Termination { get; set; }

        [Display(Name = "Manager")]
        public string Mg_Name { get; set; }
        public bool Sp_Active { get; set; }
    }
}
