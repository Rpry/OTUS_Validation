using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ValidationAttributes
{
    /// <summary>
    /// Коллекция должна иметь хотя бы один элемент 
    /// </summary>
    public class MustHaveAtLeastOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IList list)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}