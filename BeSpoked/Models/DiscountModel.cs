using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class DiscountModel : TrackableModel
    {
        public DiscountModel()
        {
            Dc_Date_Beg = DateTime.Today;
            Dc_Date_End = DateTime.Today.AddDays(30);
        }
        public int Dc_Key { get; set; }
        public int Dc_Pr_Key { get; set; }
        public DateTime Dc_Date_Beg { get; set; }
        public DateTime Dc_Date_End { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(double.Epsilon, 1.0, ErrorMessage = "Must be between 1 and 0")]
        public decimal Dc_Percent { get; set; }
    }
}
