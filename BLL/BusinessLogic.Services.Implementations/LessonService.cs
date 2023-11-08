﻿using BusinessLogic.Abstractions;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Contracts;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Сервис работы с уроками
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;

        public LessonService(
            IMapper mapper,
            ILessonRepository lessonRepository)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        public async Task<ICollection<LessonDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Lesson> entities = await _lessonRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Lesson>, ICollection<LessonDto>>(entities);
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО урока</returns>
        public async Task<LessonDto> GetByIdAsync(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            return _mapper.Map<LessonDto>(lesson);
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="lessonDto">ДТО урока</param>
        /// <returns>идентификатор</returns>
        public async Task<int> CreateAsync(LessonDto lessonDto)
        {
            var entity = _mapper.Map<LessonDto, Lesson>(lessonDto);
            entity.CourseId = lessonDto.CourseId;
            var res = await _lessonRepository.AddAsync(entity);
            await _lessonRepository.SaveChangesAsync();
            return res.Id;
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="lessonDto">ДТО урока</param>
        public async Task UpdateAsync(int id, LessonDto lessonDto)
        {
            var entity = _mapper.Map<LessonDto, Lesson>(lessonDto);
            entity.Id = id;
            _lessonRepository.Update(entity);
            await _lessonRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task DeleteAsync(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            lesson.Deleted = true; 
            await _lessonRepository.SaveChangesAsync();
        }
    }
}