using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace LykkePay.Common.Validation
{
    /// <summary>
    /// Check whether value is valid partition and row key
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class RowKeyAttribute : UseWithRequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (IsRequiredResponsibility(value)) return true;

            if (value is ICollection<string> list)
            {
                return list.All(x => x.IsValidPartitionOrRowKey());
            }

            return value.ToString().IsValidPartitionOrRowKey();
        }

        public override string FormatErrorMessage(string name)
        {
            return "Invalid characters used.";
        }
    }
}
