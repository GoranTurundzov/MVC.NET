using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class NumberService
    {
        public int? Sum(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        public bool IsFirstLarger(int num1 , int num2)
        {
            return num1 > num2;
        }

        public string GetDigitName(int num)
        {
            List<string> names = new List<string>()
            {
                "zero", "one", "two", "three", "four" , "five" , "six" , "seven", "eight", "nine"
            };
            return names[num];

        }
    }

    [TestClass]
    public class NumberTests
    {
        private readonly NumberService _numberService;

        public NumberTests()
        {
            _numberService = new NumberService();
        }
        [TestMethod]
        public void Sum_PositiveInteregers_ResultNumber()
        {
            //Arange
            int num1 = 5;
            int num2 = 10;
            int? expectedResult = 15;

            //ACT

            int? result = _numberService.Sum(num1, num2);

            //ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Sum_LargeNumberIntegers_Null()
        {
            int num1 = 2200000;
            int num2 = 2200000;

            int? result = _numberService.Sum(num1, num2);

            Assert.IsNull(result);
        }
    }
}
