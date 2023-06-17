using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Services;
using System.Collections.Generic;
using System;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopConversionsController : Controller
    {
        private readonly IIntegerConversionService _Service;

        public TopConversionsController(IIntegerConversionService Service)
        {
            _Service = Service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var top10PopularNumbers = _Service.GetMostPopularNumber();

                return Ok(top10PopularNumbers);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
