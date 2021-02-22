using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiledCoding.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public class CreditCardValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";

            Regex regex = new Regex(strRegex);

            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
