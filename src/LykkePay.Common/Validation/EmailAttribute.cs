using System;
using Common;

namespace LykkePay.Common.Validation
{
    /// <summary>
    /// Check whether value is valid email
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class EmailAttribute : UseWithRequiredAttribute
    {
        private const string Message = "The {0} field is not a valid e-mail address.";

        public override bool IsValid(object value)
        {
            if (IsRequiredResponsibility(value)) return true;

            return value.ToString().IsValidEmail();
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(Message, name);
        }
    }
}
