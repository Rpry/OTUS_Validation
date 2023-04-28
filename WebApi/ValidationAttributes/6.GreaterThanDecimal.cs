﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApi.ValidationAttributes
{
    /// <summary>
    /// Атрибут для проверки того, что значение decimal больше переданного  
    /// </summary>
    public class GreaterThanDecimal : ValidationAttribute
    {
        private readonly decimal _val;
        private readonly string _culture;

        public GreaterThanDecimal(double val, string culture = "en-GB")
        {
            _val = (decimal) val;
            _culture = culture;
        }

        public override bool IsValid(object value)
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture(_culture);

            if (value != null && decimal.TryParse(value.ToString(), style, culture, out var result))
            {
                if (result > _val)
                {
                    return true;
                }
            }

            return false;
        }
    }
}