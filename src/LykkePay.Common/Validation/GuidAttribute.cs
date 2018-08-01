using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace LykkePay.Common.Validation
{
    /// <summary>
    /// Check whether value is valid GUID
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class GuidAttribute : UseWithRequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (IsRequiredResponsibility(value)) return true;

            if (value is ICollection<string> list)
            {
                return list.All(x => x.IsGuid());
            }

            return value.ToString().IsGuid();
        }

        public override string FormatErrorMessage(string name)
        {
            return "Invalid guid value.";
        }
    }
}
