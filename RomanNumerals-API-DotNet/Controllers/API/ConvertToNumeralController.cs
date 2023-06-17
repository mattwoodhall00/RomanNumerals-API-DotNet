using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Services;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertToNumeralController : ControllerBase
    {
        private readonly IIntegerConversionService _conversionService;

        public ConvertToNumeralController(IIntegerConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet]
        public IActionResult Get(int number)
        {
            try
            {
                string romanNumeral = _conversionService.ToRomanNumerals(number);
                return Ok(romanNumeral);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
    
}