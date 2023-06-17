using System;

namespace RomanNumerals_API_DotNet.Models
{
    public class Conversion
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string RomanNumeral { get; set; }
        public DateTime Created { get; set; }
    }
}
