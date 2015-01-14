using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using String_Calculator_Kata;

namespace String_Calculator_Unit_Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AddEmptyString()
        {
            int result = Calculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddOneNumberString()
        {
            int result = Calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AddNoNumberWithDelimiterString()
        {
            int result = Calculator.Add(",");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddNoNumberWithIncorrectDelimiterString()
        {
            int result = Calculator.Add("|");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddTwoNumberString()
        {
            int result = Calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddThreeNumberString()
        {
            int result = Calculator.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddThreeNumberWithNewlineString()
        {
            int result = Calculator.Add("1\n2\n3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddThreeNumberWithNewlineMixedString()
        {
            int result = Calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddOneNumberWithNewlineMixedStrangeString()
        {
            int result = Calculator.Add("1,\n");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AddTwoNumberWithNewlineMixedStrangeString()
        {
            int result = Calculator.Add("1,\n3");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void AddTwoNumberWithVariableDelimiterString()
        {
            int result = Calculator.Add("//;\n1;3");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void AddTwoNumberWithVariableDelimiterTwoString()
        {
            int result = Calculator.Add("///\n1/3");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void AddTwoNumberWithVariableDelimiterAndStandardString()
        {
            int result = Calculator.Add("//;\n1;3\n5,6");

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void SingleNegativeNumber()
        {
            string errorMessage = string.Empty;

            try
            {
                Calculator.Add("-2");
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
            }

            Assert.AreEqual("negatives not allowed: -2", errorMessage);
        }

        [TestMethod]
        public void MultipleNegativeNumbers()
        {
            string errorMessage = string.Empty;

            try
            {
                Calculator.Add("-2,3\n-44");
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
            }

            Assert.AreEqual("negatives not allowed: -2,-44", errorMessage);
        }
    }
}
