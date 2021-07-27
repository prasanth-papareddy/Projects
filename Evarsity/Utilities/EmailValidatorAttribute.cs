using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.Utilities
{
    public class EmailValidatorAttribute : ValidationAttribute
    {
        private readonly string Validation;
        public EmailValidatorAttribute( string Validation )
        {
            this.Validation = Validation;
        }

        public override bool IsValid(object value)
        {
            string[] val = value.ToString().Split('@');
            return val[1].ToUpper() == Validation.ToUpper();          
        }
    }
}
