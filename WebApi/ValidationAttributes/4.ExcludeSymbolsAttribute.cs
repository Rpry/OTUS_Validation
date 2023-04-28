using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class ExcludeSymbolsAttribute : ValidationAttribute
    {
        private char[] _forbiddenSymbols;
        
        public ExcludeSymbolsAttribute(char[] forbiddenSymbols)
        {
            _forbiddenSymbols = forbiddenSymbols;
            ErrorMessage = string.Format(errors.ExcludeSymbolsAttribute_ExcludeSymbolsAttribute_Поле_не_должно_содержать_символы____0__, string.Join(",", forbiddenSymbols));
        }
        
        public override bool IsValid(Object value)
        {
            if (value == null)
            {
                return true;
            }
            bool result = true;
            var validatedObjectStr = Convert.ToString(value);

            foreach (var forbiddenSymbol in _forbiddenSymbols)
            {
                if (validatedObjectStr.Contains(forbiddenSymbol))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
