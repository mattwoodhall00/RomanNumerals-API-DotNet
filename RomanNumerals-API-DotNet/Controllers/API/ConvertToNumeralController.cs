using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertToNumeralController : ControllerBase
    {
        public string Get(int number)
        {
            throw new NotImplementedException();
        }
    }
}