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
    /// Cервис работы с курсами
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(
            IMapper mapper,
            ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns></returns>
        public async Task<List<CourseDto>> GetPagedAsync(int page, int pageSize)
        {
            var entities = await _courseRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<List<Course>, List<CourseDto>>(entities);
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО курса</returns>
        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="courseDto">ДТО курса</param>
        /// <returns>идентификатор</returns>
        public async Task<int> CreateAsync(CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            var res = await _courseRepository.AddAsync(entity);
            await _courseRepository.SaveChangesAsync();
            return res.Id;
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="courseDto">ДТО курса</param>
        public async Task Update(int id, CourseDto courseDto)
        {
            var entity = _mapper.Map<CourseDto, Course>(courseDto);
            entity.Id = id;
            _courseRepository.Update(entity);
            await _courseRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        public async Task DeleteAsync(int id)
        {
            var course = await _courseRepository.GetAsync(id);
            course.Deleted = true; 
            await _courseRepository.SaveChangesAsync();
        }
    }
}