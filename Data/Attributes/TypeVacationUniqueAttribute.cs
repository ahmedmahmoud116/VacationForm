using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Data.DBContexts;

namespace Data.Models.Attributes
{
    public class TypeVacationUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (VacationContext)validationContext.GetService(typeof(VacationContext));
            var entity = _context.Vacations.SingleOrDefault(e => e.Type == value.ToString()); //ya2ma batrg3 al value aw null

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage(string type)
        {
            return $"Name {type} is already in use.";
        }
    }
}
