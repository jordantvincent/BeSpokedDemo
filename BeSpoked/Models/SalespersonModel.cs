using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class SalespersonModel : TrackableModel
    {
        public SalespersonModel()
        {
            Sp_Date_Start = DateTime.Today;
        }

        public int Sp_Key { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Sp_Name_First { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Sp_Name_Last { get; set; }

        public string Sp_Name_FL { get; set; }
        
        [Required]
        [Display(Name = "Address Line 1")]
        public string Sp_Addr_1 { get; set; }

        [Required]
        [Display(Name = "Address Line 2")]
        public string Sp_Addr_2 { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public string Sp_Phone { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime Sp_Date_Start { get; set; }
        public DateTime Sp_Date_Termination { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public int Sp_Mg_Key { get; set; }
    }
}
