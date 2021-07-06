using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add(string input)
		{
			int sum = 0;

			if (input.Length == 0)
			{
				return sum;
			}

			string[] numbers = input.Split(',', '\n').ToArray();
			foreach  (string number in numbers)
			{
				sum += Convert.ToInt32(number);
			}

			return sum;
		}
	}
}
