using NUnit.Framework;

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
	}
}