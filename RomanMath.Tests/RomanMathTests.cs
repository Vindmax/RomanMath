using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	public class RomanMathTests
	{
		[Test]
		public void Should_Throw_ArgumentNullException_When_Argument_Is_Null()
		{
			Assert.Throws<ArgumentNullException>(() => Service.Evaluate(null));
		}

		[Test]
		public void Should_Throw_ArgumentNullException_When_Argument_Is_Empty()
		{
			Assert.Throws<ArgumentNullException>(() => Service.Evaluate(""));
		}

		[Test]
		public void X_Minus_V_Should_Equal_5()
		{
			string expression = "X-V";
			int expected = 5;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IV_Plus_II_Should_Equal_6()
		{
			string expression = "IV+II";
			int expected = 6;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void MMD_Multiply_II_Should_Equal_5000()
		{
			string expression = "MMD*II";
			int expected = 5000;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void I_Plus_II_Minus_I_Should_Equal_2()
		{
			string expression = "I+II-I";
			int expected = 2;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CX_Plus_XIV_With_Whitespaces_Should_Be_Valid_Expression()
        {
			string expression = "   CX   +  XIV  ";

			Assert.DoesNotThrow(() => Service.Evaluate(expression));
        }

		[Test]
		public void CX_Plus_XIV_With_Whitespaces_Should_Be_Equal_124()
		{
			string expression = "   CX   +  XIV  ";
			int expected = 124;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void XLVIII_Multiply_XIX_Should_Be_Equal_672()
		{
			string expression = "XLVIII * XIV";
			int expected = 672;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void XLVIII_Multiply_XIX_Minus_IV_Should_Be_Equal_668()
		{
			string expression = "XLVIII * XIV - IV";
			int expected = 668;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void M_Minus_CM_Should_Be_Equal_100()
		{
			string expression = "M - CM";
			int expected = 100;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CCC_Plus_DC_Should_Be_Equal_900()
		{
			string expression = "CCC +  DC";
			int expected = 900;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void XL_Double_Minus_DCCC_Should_Throw_ArgumentException()
		{
			string expression = "XL -- DCCC";

			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}

		[Test]
		public void XL_Minus_DCCC_Should_Equal_Negative_760()
		{
			string expression = "XL - DCCC  ";
			int expected = -760;
			int actual = Service.Evaluate(expression);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Plus_XL_Minus_DCCC_Should_Throw_ArgumentException()
		{
			string expression = " + XL - DCCC  ";
			
			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}

		[Test]
		public void XL_Minus_DCCC_Minus_Should_Throw_ArgumentException()
		{
			string expression = " XL - DCCC - ";

			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}

		[Test]
		public void XL_Minus_DCCC_Minus_10_Should_Throw_ArgumentException()
		{
			string expression = " XL - DCCC - 10";

			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}

		[Test]
		public void X_Divide_By_II_Should_Throw_ArgumentException()
		{
			string expression = "X / II";

			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}

		[Test]
		public void V_Plus_X_Minus_V_With_Parentheses_Should_Throw_ArgumentException()
		{
			string expression = "V + (X - V)";

			Assert.Throws<ArgumentException>(() => Service.Evaluate(expression));
		}
	}
}