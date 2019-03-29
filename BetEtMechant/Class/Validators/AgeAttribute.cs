using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Class.Validators
{
    public class AgeAttribute : ValidationAttribute
    {
        private int ageMin;
        public AgeAttribute(int AgeMin)
        {
            ageMin = AgeMin;
        }
        public override bool IsValid(object value)
        {
            if(value is DateTime)
            {
                var dt = (DateTime)value;
                return dt.AddYears(ageMin) <= DateTime.Now;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, this.ageMin);
        }
    }
}
