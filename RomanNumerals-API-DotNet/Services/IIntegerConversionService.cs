using RomanNumerals_API_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services
{
    public interface IIntegerConversionService
    {
        string ToRomanNumerals(int input);

        List<Conversion> GetLatestConversions();

        List<int> GetMostPopularNumber();

    }
}
