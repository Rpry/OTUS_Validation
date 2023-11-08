using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApi.ValidationAttributes
{
    /// <summary>
    /// Валидатор, проверяющий что текущая дата позже (больше) чем та которая передана в аргументе
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class DateLaterThen : CompareAttribute
    {
        public DateLaterThen(string otherProperty) : base(otherProperty)
        {
        }
        
        protected override ValidationResult IsValid([Required]object value, ValidationContext validationContext)
        {
            var otherLessDateTimePropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
            if (otherLessDateTimePropertyInfo == null)
            {
                return new ValidationResult($"Не задан аргумент {validationContext.ObjectType.FullName}");
            }
            object otherLessDateTimePropertyValue = otherLessDateTimePropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (otherLessDateTimePropertyValue == null)
            {
                return new ValidationResult($"Не задан аргумент {validationContext.ObjectType.FullName}");
            }
            if(!DateTime.TryParse(otherLessDateTimePropertyValue.ToString(), out DateTime otherLessDateTimeProperty)
               || otherLessDateTimeProperty == new DateTime())
            {
                return new ValidationResult($"Значение {otherLessDateTimePropertyValue} даты {otherLessDateTimePropertyInfo.Name}, c которой производится сравнение, задана некорректно");
            }
            if(!DateTime.TryParse(value.ToString(), out DateTime valueAsDateTime)
               || valueAsDateTime == new DateTime())
            {
                return new ValidationResult($"Дата {value} задана некорректно");
            }
            if (valueAsDateTime <= otherLessDateTimeProperty)
            {
                return new ValidationResult($"Дата {valueAsDateTime} должна быть больше {otherLessDateTimeProperty}");
            }
            return null;
        }
    }
}
