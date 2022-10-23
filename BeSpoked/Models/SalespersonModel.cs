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

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string Sp_Name_First { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string Sp_Name_Last { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address Line 1")]
        [MaxLength(50)]
        public string Sp_Addr_1 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address Line 2")]
        [MaxLength(50)]
        public string Sp_Addr_2 { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Please enter valid number")]
        [MinLength(10, ErrorMessage = "Please enter valid number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid number")]
        [Display(Name = "Phone Number")]
        public string Sp_Phone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Start Date")]
        public DateTime Sp_Date_Start { get; set; }
        public DateTime Sp_Date_Termination { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an option")]
        [Display(Name = "Manager")]
        public int Sp_Mg_Key { get; set; }
    }
}
