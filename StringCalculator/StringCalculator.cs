using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add(string input)
		{
			if (input.Length == 0)  // Increase performance for empty string
				return 0;

			int[] numbers = ExtractNumbers(input);
			int sum = Sum(numbers);
			return sum;
		}

		private static int[] ExtractNumbers(string input)
		{
			List<int> numbersList = new List<int>();

			var numbersStrings = Regex.Matches(input, @"-?\d+");

			foreach (var item in numbersStrings)
			{
				numbersList.Add(Convert.ToInt32(item.ToString()));
			}
			int[] numbers = numbersList.ToArray();

			CheckNegative(numbers);

			return numbers;
		}

		private static int Sum(int[] numbers)
		{
			int sum = 0;

			foreach (int number in numbers)
				if (number < 1000)
					sum += number;

			return sum;
		}

		private static void CheckNegative(int[] numbers)
		{
			string exceptionNumbers = "";

			foreach (int number in numbers)
				if (number < 0)
					exceptionNumbers += string.Format("{0} ", number);

			if (exceptionNumbers.Length != 0)
				throw new ArgumentException(exceptionNumbers);
		}
	}
}
