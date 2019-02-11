using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals_API_DotNet.Tests
{
    [TestClass]
    public class IntegerConversionTests
    {
        private IntegerConversionService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new IntegerConversionService();
        }

        [TestMethod]
        public void ConvertsCorrectly()
        {
            var cases = new List<(int value, string expected)>()
            {
                (1, "I"),
                (4, "IV"),
                (5, "V"),
                (9, "IX"),
                (10, "X"),
                (100, "C"),
                (40, "XL"),
                (50, "L"),
                (90, "XC"),
                (400, "CD"),
                (500, "D"),
                (900, "CM"),
                (1000, "M")
            };

            foreach (var testCase in cases)
            {
                var actual = _service.ToRomanNumerals(testCase.value);
                Assert.AreEqual(actual, testCase.expected);
            }
        }

        [TestMethod]
        public void ConvertsSomeSpecialCases()
        {
            var actual = _service.ToRomanNumerals(3999);
            Assert.AreEqual(actual, "MMMCMXCIX");

            actual = _service.ToRomanNumerals(2016);
            Assert.AreEqual(actual, "MMXVI");

            actual = _service.ToRomanNumerals(2018);
            Assert.AreEqual(actual, "MMXVIII");
        }
    }
}
