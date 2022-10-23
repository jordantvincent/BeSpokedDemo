using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpoked.Models
{
    public class SalespersonTerminateModel : IValidatableObject
    {
        public SalespersonTerminateModel()
        {
            Sp_Date_Terminate = DateTime.Today;
        }
        public int Sp_Key { get; set; }

        [Display(Name = "Termination Date")]
        [Required]
        public DateTime Sp_Date_Terminate { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime Sp_Date_Started { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Sp_Date_Terminate < Sp_Date_Started)
            {
                yield return new ValidationResult(
                    errorMessage: "Termination date must be after start date",
                    memberNames: new[] { "Sp_Date_Terminate" }
               );
            }
        }
    }
}
