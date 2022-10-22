using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class EmployeeModel : TrackableModel
    {
        public EmployeeModel()
        {
            Em_Date_Start = DateTime.Today;
        }

        public int Em_Key { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Em_Name_First { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Em_Name_Last { get; set; }

        public string Em_Name_FL { get; set; }
        
        [Required]
        [Display(Name = "Address Line 1")]
        public string Em_Addr_1 { get; set; }

        [Required]
        [Display(Name = "Address Line 2")]
        public string Em_Addr_2 { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public string Em_Phone { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime Em_Date_Start { get; set; }
        public DateTime Em_Date_Termination { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int Em_Dm_Key { get; set; }
    }
}
