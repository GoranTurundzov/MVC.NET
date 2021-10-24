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

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsFirstLarger_FirstIsNotLarger_False()
        {
            int num1 = 500;
            int num2 = 501;

            bool result = _numberService.IsFirstLarger(num1, num2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsFirstLarger_FirstIsNotLarger_True()
        {
            int num1 = 502;
            int num2 = 501;

            bool result = _numberService.IsFirstLarger(num1, num2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetDigitName_SingleDigit_SingleDigitName()
        {
            int num1 = 5;


            string expecte = "five";

            string result = _numberService.GetDigitName(num1);

            Assert.AreEqual(expecte, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetDigitName_MultiDigit_Exception_Method1()
        {
            //Arrange
            int num1 = 56;
            //Act Assery
            _numberService.GetDigitName(num1);

        }
        [TestMethod]
        public void GetDigitName_MultiDigit_Exception_Method2()
        {

            //Arrange
            int num1 = 56;
            //Act Assery
            Assert
                .ThrowsException<ArgumentOutOfRangeException>(() =>
                _numberService.GetDigitName(num1));

        }

    }
}
