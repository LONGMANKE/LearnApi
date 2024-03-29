﻿using LearnAPI.Modal;
using LearnAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await this.service.Getall();
            if (data == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(data);
        }
        [HttpGet("Getbycode")]
        public async Task<IActionResult> Getbycode(string code)
        {
            var data = await this.service.Getbycode(code);
            if (data == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Customermodal _data)
        {
            var data = await this.service.Create(_data);
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Customermodal _data, string code)
        {
            var data = await this.service.Update(_data, code);
            return Ok(data);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(string code)
        {
            var data = await this.service.Remove(code);
            return Ok(data);
        }
    }
   
}

