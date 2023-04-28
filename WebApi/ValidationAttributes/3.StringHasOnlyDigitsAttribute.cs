using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApi.ValidationAttributes
{
    /// <summary>
    /// Атрибут для проверки на наличие в строке только цифр
    /// </summary>
    public class StringHasOnlyDigitsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string str && str.Trim().All(char.IsDigit);
        }
    }
}