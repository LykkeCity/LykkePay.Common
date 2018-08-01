using System;
using System.Collections;

namespace LykkePay.Common.Validation
{
    /// <summary>
    /// Check whether collection contains any item
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class NotEmptyCollectionAttribute : UseWithRequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (IsRequiredResponsibility(value)) return true;

            if (value is ICollection collection)
            {
                return collection.Count != 0;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The field {name} must contain at least one item.";
        }
    }
}
