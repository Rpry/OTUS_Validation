using BusinessLogic.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Cервис работы с курсами (интерфейс)
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        Task<List<CourseDto>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО курса</returns>
        Task<CourseDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="courseDto">ДТО курса</para
        Task<int> CreateAsync(CourseDto courseDto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="courseDto">ДТО курса</param>
        Task Update(int id, CourseDto courseDto);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        Task DeleteAsync(int id);
    }
}