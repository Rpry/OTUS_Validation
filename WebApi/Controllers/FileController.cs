// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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
        //public IActionResult Create([FromForm(Name ="file")]IFormFile file)
        public async Task<IActionResult> Create([FromForm]FormDataModel model)
        {
            return Ok();
        }
    }
}