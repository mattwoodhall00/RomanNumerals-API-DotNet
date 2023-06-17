using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.Controllers.API;
using RomanNumerals_API_DotNet.Data;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RomanNumerals_API_DotNet.Tests
{
    [TestClass]
    public class IntegerConversionTests
    {
        private IntegerConversionService _service;
        private ConvertToNumeralController _convertController;
        private RecentConversionsController _recentConversionsController;
       

        [TestInitialize]
        public void TestInitialize()
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RomanNumeralTest;Trusted_Connection=True;");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);


            _service = new IntegerConversionService(dbContext);
            _convertController = new ConvertToNumeralController(_service);
            _recentConversionsController = new RecentConversionsController(_service);
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

        [TestMethod]
        public void DoesNotExceed3999_BadRequest()
        {
            int number = 4000;

            var response = _convertController.Get(number) as BadRequestObjectResult;

            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void NumberNotBelowOne_BadRequest()
        {
            int number = 0;

            var response = _convertController.Get(number) as BadRequestObjectResult;

            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void NumberNotNegative_BadRequest()
        {
            int number = -1;

            var response = _convertController.Get(number) as BadRequestObjectResult;

            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }

    }
}
