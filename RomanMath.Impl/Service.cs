using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanMath.Impl
{
	public static class Service
	{
		private static string pattern = @"^(((?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3}))+\s*(\*|\+|\-)\s*)+(((?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3}))+\s*)$";
		private static Dictionary<string, int> romanNumberPairs;
		private static Dictionary<char, Func<int, int, int>> operators;
		static Service()
		{
			romanNumberPairs = new Dictionary<string, int>()
			{
				{"I",  1 },
				{"IV", 4 },
				{"V",  5 },
				{"IX", 9 },
				{"X",  10 },
				{"XL", 40 },
				{"L",  50 },
				{"XC", 90 },
				{"C",  100 },
				{"CD", 400 },
				{"D",  500 },
				{"CM", 900 },
				{"M",  1000 }
			};

			operators = new Dictionary<char, Func<int, int, int>>()
			{
				{ '+', (operand1, operand2) => operand1 + operand2 },
				{ '-', (operand1, operand2) => operand1 - operand2 },
				{ '*', (operand1, operand2) => operand1 * operand2 }
			};
		}

		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static int Evaluate(string expression)
		{
			if (String.IsNullOrEmpty(expression))
				throw new ArgumentNullException("Expression is null or empty");

			expression = Regex.Replace(expression, @"[\s]", "");
			var match = Regex.Match(expression, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
				int? result = null;
				var symbols = match.Value.ToCharArray();

				(int, int) num_idx_tuple;
				char oper = ' ';
				int index = 0;
				do
				{
					num_idx_tuple = GetRomanNumber(symbols, index);
					index = num_idx_tuple.Item2;

					if(result is null)
						result = num_idx_tuple.Item1;
					else
                    {
						var operation = operators[oper];
						result = operation(result.Value, num_idx_tuple.Item1);
					}
					oper = symbols[index];
					index++;
				}
				while (num_idx_tuple.Item2 != 0);

				return result.Value;
            }
			throw new ArgumentException("Invalid expression");
		}

		private static (int, int) GetRomanNumber(char[] symbols, int index)
        {
			int romanNumber = 0;
			char prevSymbol;
			string symbol;
            for (int i = index; i < symbols.Length; i++)
            {
				prevSymbol = symbols[i - 1 < index ? index : i - 1];
				symbol = symbols[i].ToString();

				if (romanNumberPairs.ContainsKey(prevSymbol + symbol))
					romanNumber += romanNumberPairs[prevSymbol + symbol] - romanNumberPairs[prevSymbol.ToString()];
				else if(romanNumberPairs.ContainsKey(symbol))
					romanNumber += romanNumberPairs[symbol];
				else
					return (romanNumber, i);
            }
			return (romanNumber, 0);
        }
	}
}
