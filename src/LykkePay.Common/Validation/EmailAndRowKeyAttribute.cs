using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common;

namespace LykkePay.Common.Validation
{
    /// <summary>
    /// Check whether value is valid email or valid partition and row key
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class EmailAndRowKeyAttribute : UseWithRequiredAttribute
    {
        private const string Message = "The {0} field is not a valid e-mail address.";

        public override bool IsValid(object value)
        {
            if (IsRequiredResponsibility(value)) return true;

            return value.ToString().IsValidEmailAndRowKey();
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(Message, name);
        }
    }
}
