using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class GuidNotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            var result = false;
            if (value != null && Guid.TryParse(value.ToString(), out var guid))
            {
                if (guid != Guid.Empty)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}