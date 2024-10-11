using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_3_entitiy_task.Models
{
    public class validateDOB : ValidationAttribute
    {
        protected override ValidationResult 
            IsValid(object value, ValidationContext validationContext)
        {
            DateTime dob = Convert.ToDateTime(value);
            if (dob <= DateTime.Now.AddYears(-20))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("DOB must be at least 20 years old");
            }
        }
    }
}