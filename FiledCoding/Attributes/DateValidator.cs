using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public class DatesValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((DateTime)value >= DateTime.Now)
                return true;
            return false;
        }

    }
}
