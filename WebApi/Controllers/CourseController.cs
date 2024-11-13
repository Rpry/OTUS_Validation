using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Abstractions;
using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private ICourseService _service;
        private IMapper _mapper;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        //[HttpGet()]
        //public async Task<IActionResult> GetWithRouteAsync(int id)
        //public async Task<IActionResult> GetWithRouteAsync([FromQuery]int id)
        //public async Task<IActionResult> GetWithRouteAsync(int id, [FromQuery]int aux)
        public async Task<IActionResult> GetWithRouteAsync(int id, [FromHeader]int aux)
        {
            return Ok(_mapper.Map<CourseCardModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        //public async Task<IActionResult> AddAsync([FromBody]CourseModel courseModel)
        public async Task<IActionResult> AddAsync([FromForm]CourseModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                //Обработка ошибки валидации
            }
            return Ok(await _service.CreateAsync(_mapper.Map<CourseDto>(courseModel)));
        }
       
        [HttpPut("{id}")]
        //public async Task<IActionResult> EditAsync([Range(1, Int32.MaxValue)]int id, CourseModel model)
        public async Task<IActionResult> EditAsync(int id, CourseModel model)
        {
            await _service.Update(id, _mapper.Map<CourseDto>(model));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync([FromForm]int page, [FromForm]int itemsPerPage)
        {
            return Ok(_mapper.Map<List<CourseDto>, List<CourseCardModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}