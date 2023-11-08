using System.Collections.Generic;
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
    public class LessonController: ControllerBase
    {
        private ILessonService _service;
        private readonly ILogger<LessonController> _logger;
        private IMapper _mapper;

        public LessonController(ILessonService service, ILogger<LessonController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<LessonModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(LessonModel lessonDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<LessonDto>(lessonDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, LessonModel lessonDto)
        {
            await _service.UpdateAsync(id, _mapper.Map<LessonDto>(lessonDto));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<LessonModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}