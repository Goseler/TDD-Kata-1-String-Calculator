using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add(string input)
		{
			if (input.Length == 0)
				return 0;

			int startIndex = FindStartIndex(input);
			List<char> delimiters = FindDelimiters(startIndex, input);
			int[] numbers = GetNumbers(input, startIndex, delimiters);
			int sum = Sum(numbers);

			return sum;
		}

		private static int FindStartIndex(string input)
		{
			int startIndex = 0;

			if (input[0] == '/' && input[1] == '/')
			{
				if (input[4] == '\n')
					startIndex = 4;
				startIndex = 3;
			}

			return startIndex;
		}

		private static List<char> FindDelimiters(int startIndex, string input)
		{
			List<char> delimiters = new List<char>();

			if (startIndex == 0)
			{
				delimiters.Add(',');
				delimiters.Add('\n');
			}
			else
				delimiters.Add(input[2]);

			return delimiters;
		}

		private static int Sum(int[] numbers)
		{
			int sum = 0;

			foreach (int number in numbers)
				if (number < 1000)
					sum += number;

			return sum;
		}

		private static int[] GetNumbers(string input, int startIndex, List<char> delimiters)
		{
			string cuted = input.Substring(startIndex);
			string[] numbersStrings = cuted.Split(delimiters.ToArray());
			int[] numbers = Array.ConvertAll(numbersStrings, int.Parse);
			CheckNegative(numbers);

			return numbers;
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
