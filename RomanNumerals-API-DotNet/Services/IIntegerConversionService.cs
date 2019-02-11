using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services
{
    public interface IIntegerConversionService
    {
        string ToRomanNumerals(int input);
    }
}
