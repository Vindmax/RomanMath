using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			try
			{
				var result = Service.Evaluate("III * II");
				System.Console.WriteLine(result);
			}
			catch (ArgumentNullException ex)
			{
				System.Console.WriteLine($"Argument null exception: {ex.Message}");
			}
			catch (ArgumentException ex)
			{
				System.Console.WriteLine($"Argument exception: {ex.Message}");
			}
			System.Console.ReadKey();
		}
	}
}
