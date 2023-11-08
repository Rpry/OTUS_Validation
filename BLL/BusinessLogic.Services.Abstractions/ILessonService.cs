using BusinessLogic.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Сервис работы с уроками (интерфейс)
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        Task<ICollection<LessonDto>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО урока</returns>
        Task<LessonDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="lessonDto">ДТО урока</param>
        /// <returns>идентификатор</returns>
        Task<int> CreateAsync(LessonDto advertisementDto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="lessonDto">ДТО урока</param>
        Task UpdateAsync(int id, LessonDto advertisementDto);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        Task DeleteAsync(int id);
    }
}