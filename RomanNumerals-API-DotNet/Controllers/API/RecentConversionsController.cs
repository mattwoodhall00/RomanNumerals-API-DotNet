using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Models;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecentConversionsController : ControllerBase
    {
        private readonly IIntegerConversionService _Service;

        public RecentConversionsController(IIntegerConversionService conversionHistoryService)
        {
            _Service = conversionHistoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retrieve the latest conversions
                List<Conversion> latestConversions = _Service.GetLatestConversions();

                var response = latestConversions.Select(c => c.Number).ToList();

                return Ok(response);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
