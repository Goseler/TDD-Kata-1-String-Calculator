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

			//int startIndex = GetStartIndex(input);
			//List<string> delimiters = GetDelimiters(startIndex, input);
			//int[] numbers = GetNumbers(input, startIndex, delimiters);
			//int sum = Sum(numbers);

			//string[] numbersStrings = Regex.Split(input, @"\D")
			//						  .Where(str => !string.IsNullOrEmpty(str))
			//						  .ToArray();

			//var numbersStrings = Regex.Matches(input, @"-?\d+");
			//int[] numbers = Array.ConvertAll(numbersStrings, int.Parse);

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

		//private static int GetStartIndex(string input)
		//{
		//	int startIndex = 0;

		//	if (input[0] == '/' && input[1] == '/')
		//	{
		//		if (input[4] == '\n')
		//			startIndex = 4;
		//		startIndex = 3;
		//	}

		//	return startIndex;
		//}

		//private static List<string> GetDelimiters(int startIndex, string input)
		//{
		//	List<string> delimiters = new List<string>();

		//	if (startIndex == 0)
		//	{
		//		delimiters.Add(",");
		//		delimiters.Add("\n");
		//	}
		//	else
		//		delimiters.Add(input[2].ToString());

		//	return delimiters;
		//}

		private static int Sum(int[] numbers)
		{
			int sum = 0;

			foreach (int number in numbers)
				if (number < 1000)
					sum += number;

			return sum;
		}

		//private static int[] GetNumbers(string input, int startIndex, List<string> delimiters)
		//{
		//	string cuted = input.Substring(startIndex);
		//	string[] numbersStrings = cuted.Split(delimiters.ToArray(), StringSplitOptions.None);
		//	//string[] numbersStrings = Regex.Split(input, @"-?\d+");
		//	int[] numbers = Array.ConvertAll(numbersStrings, int.Parse);
		//	CheckNegative(numbers);

		//	return numbers;
		//}

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
