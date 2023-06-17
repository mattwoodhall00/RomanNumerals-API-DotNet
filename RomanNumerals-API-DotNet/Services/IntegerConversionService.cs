using RomanNumerals_API_DotNet.Data;
using RomanNumerals_API_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Services
{
    public class IntegerConversionService : IIntegerConversionService
    {
        private readonly ApplicationDbContext _dbContext;

        public IntegerConversionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string ToRomanNumerals(int input)
        {
            int originalInput = input; // Store the original input value

            //check input validation
            if (input < 1 || input > 3999)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Number must be between 1 and 3999.");
            }

            // store roman numeral values
            StringBuilder romanNumeral = new StringBuilder();
            int[] decimalValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            // Perform conversion
            for (int i = 0; i < decimalValues.Length; i++)
            {
                while (input >= decimalValues[i])
                {
                    romanNumeral.Append(romanSymbols[i]);
                    input -= decimalValues[i];
                }
            }

            // Create a Conversion object
            var conversion = new Conversion
            {
                Number = originalInput,
                RomanNumeral = romanNumeral.ToString(),
                Created = DateTime.UtcNow
            };

            // Add the conversion to the database
            _dbContext.Conversions.Add(conversion);
            _dbContext.SaveChanges();


            //return for the api (ConvertToNumeral)
            return romanNumeral.ToString();
        }

        public List<Conversion> GetLatestConversions()
        {
            return _dbContext.Conversions
                .OrderByDescending(c => c.Created)
                .Take(10)
                .ToList();
        }

        public List<int> GetMostPopularNumber()
        {
             return _dbContext.Conversions
            .GroupBy(c => c.Number)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .Take(10)
            .ToList();
        }
    }
}
