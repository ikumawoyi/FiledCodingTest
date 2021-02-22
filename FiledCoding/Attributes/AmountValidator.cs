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
    public class AmountValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strRegex = @"(^\d*\.?\d*[1-9]+\d*$)|(^[1-9]+\d*\.\d*$)";

            Regex regex = new Regex(strRegex);
            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
