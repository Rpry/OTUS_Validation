using AutoMapper;
using BusinessLogic.Contracts;
using DataAccess.Entities;
using WebApi.Models;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class CourseMappingsProfile : Profile
    {
        public CourseMappingsProfile()
        {
            CreateMap<CourseModel, CourseDto>()
                .ForMember(s => s.Lessons, map => map.Ignore())
                .ForMember(s => s.Id, map => map.Ignore());
            CreateMap<CourseDto, CourseCardModel>();
        }
    }
}
