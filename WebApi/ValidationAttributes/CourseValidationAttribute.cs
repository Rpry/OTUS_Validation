using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CourseValidationAttribute : ValidationAttribute
    {
        public CourseValidationAttribute()
        {
            ErrorMessage = string.Format($"Валидация класса {nameof(CourseValidationAttribute)} не пройдена");
        }
        
        public override bool IsValid(object value)
        {
            var course = value as CourseModel;
            if (course == null)
            {
                throw new NotSupportedException();
            }
            if (course.Name == Constants.DotNetCourseName && course.Price > Constants.DotNetCourseMaxPrice)
            {
                return false;
            }

            return true;
        }
    }
}