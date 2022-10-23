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
        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="First Name")]
        public string Cu_Name_First { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name")]
        public string Cu_Name_Last { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address Line 1")]
        public string Cu_Addr_1 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address Line 2")]
        public string Cu_Addr_2 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Please enter valid number")]
        [MinLength(10, ErrorMessage = "Please enter valid number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid number")]
        [Display(Name = "Phone Number")]
        public string Cu_Phone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Start Date")]
        public DateTime Cu_Date_Start { get; set; }
    }
}
