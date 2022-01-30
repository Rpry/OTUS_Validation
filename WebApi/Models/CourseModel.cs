using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.ValidationAttributes;

namespace WebApi.Models
{
    /// <summary>
    /// ДТО курса
    /// </summary>
    //[CourseValidation]
    public class CourseModel : IValidatableObject
    {
        /// <summary>
        /// Название
        /// </summary>
        //[Required]
        [MaxLength(20)]
        [ExcludeSymbolsAttribute(new []{' '})]
        //[Required]
        [Required(ErrorMessageResourceType = typeof(Controllers_CourseController), ErrorMessageResourceName = "CourseModel_Name_ErrorMNessage")]
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        [Range(1, 10)]
        [GreaterThanDecimal(2)]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Name == Constants.DotNetCourseName && Price > Constants.DotNetCourseMaxPrice)
            {
                results.Add(new ValidationResult($"Ошибка валидации: цена курса .Net превышает { Constants.DotNetCourseMaxPrice}"));
            }
            return results;
        }
    }
    
}