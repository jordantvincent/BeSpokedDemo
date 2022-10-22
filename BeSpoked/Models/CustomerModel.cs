using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class CustomerModel : TrackableModel
    {
        public CustomerModel()
        {
            Cu_Date_Start = DateTime.Today;
        }
        public int Cu_Key { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string Cu_Name_First { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Cu_Name_Last { get; set; }

        public string Cu_Name_FL { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string Cu_Addr_1 { get; set; }

        [Required]
        [Display(Name = "Address Line 2")]
        public string Cu_Addr_2 { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Cu_Phone { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime Cu_Date_Start { get; set; }
    }
}
