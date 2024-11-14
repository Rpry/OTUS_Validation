using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost]
        //public async Task<IActionResult> Create([FromForm(Name = "file1")]IFormFile file)
        public async Task<IActionResult> Create([FromForm]FormDataModel model)
        {
            return Ok();
        }
    }
}