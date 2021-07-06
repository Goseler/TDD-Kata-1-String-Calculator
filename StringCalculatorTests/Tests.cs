using NUnit.Framework;

namespace StringCalculator
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddTest_EmptyString_ZeroExpected()
		{
			var stringCalculator = new StringCalculator();
			int expected = 0;

			int actual = stringCalculator.Add("");

			Assert.AreEqual(expected, actual);
		}
	}
}