using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldUjp.Api
{
    [Route("api/DDV")]
    [ApiController]
    public class DDVApiController : ControllerBase
    {
        private readonly IDDVRepository ddvService;

        public DDVApiController(IDDVRepository ddvService)
        {
            this.ddvService = ddvService;
        }
        [HttpGet]
        public IActionResult GetDddvObjects()
        {
            var data = ddvService.GetAll();
            return Ok(data);
        }
    }
}