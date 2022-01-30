using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Contracts;

namespace WebApi.Models
{
    /// <summary>
    /// ДТО курса
    /// </summary>
    public class CourseCardModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        [Range(1, 10)]
        public decimal Price { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public List<LessonDto> Lessons { get; set; }
    }
}