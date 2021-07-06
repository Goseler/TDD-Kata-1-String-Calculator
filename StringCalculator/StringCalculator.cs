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
			if (input.Length == 0)
			{
				return 0;
			}

			return Convert.ToInt32(input);
		}
	}
}
