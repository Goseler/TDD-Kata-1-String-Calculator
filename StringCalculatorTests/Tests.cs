using NUnit.Framework;
using System;

namespace StringCalculator
{
	public class Tests
	{
		StringCalculator stringCalculator;

		[SetUp]
		public void Setup()
		{
			stringCalculator = new StringCalculator();
		}

		[Test]
		public void AddTest_EmptyString_ZeroExpected()
		{
			int expected = 0;
			string input = "";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_OneNumber_ThisNUmber()
		{
			int expected = 1;
			string input = "1";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_TwoNumbers_SumNumbers()
		{
			int expected = 3;
			string input = "1,2";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_UnknownAmountOfNumbers_SumNumbers()
		{
			int expected = 10;
			string input = "1,2,3,4";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_LinesBetweenNumbers_SumNumbers()
		{
			int expected = 10;
			string input = "1\n2\n3,4";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_DifferentDelimiters_SumNumbers()
		{
			int expected = 3;
			string input = "//;\n1;2";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_NegativeNumbers_ThrowException()
		{
			string input = "//;\n-1;2";

			Assert.Throws<ArgumentException>(() => stringCalculator.Add(input));
		}

		[Test]
		public void AddTest_BiggerThan1000_ShouldBeIgnored()
		{
			int expected = 7;
			string input = "//%2%1000%2067%5";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_DelimitersOfAnyLength_SumNumbers()
		{
			int expected = 6;
			string input = "//***\n1***2***3";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_MultipleDelimiters_SumNumbers()
		{
			int expected = 6;
			string input = "//[*][%]\n1*2%3";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddTest_MultipleDelimitersOfAnyLength_SumNumbers()
		{
			int expected = 6;
			string input = "//[***][%%]\n1***2%%3";

			int actual = stringCalculator.Add(input);

			Assert.AreEqual(expected, actual);
		}
	}
}