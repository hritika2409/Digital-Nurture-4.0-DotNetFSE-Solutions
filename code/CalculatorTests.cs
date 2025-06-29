using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [OneTimeSetUp]
        public void Init()
        {
            _calculator = new SimpleCalculator();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _calculator.AllClear();
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 1, 0)]
        public void Addition_ShouldReturnExpected(double a, double b, double expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, 0)]
        public void Subtraction_ShouldReturnExpected(double a, double b, double expected)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(1, 1, 1)]
        public void Division_ShouldReturnExpected(double a, double b, double expected)
        {
            var result = _calculator.Division(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}
