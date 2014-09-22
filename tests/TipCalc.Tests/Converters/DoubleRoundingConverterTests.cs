using NUnit.Framework;
using TipCalc;
using System;

namespace TipCalc.Tests.Converters
{
	[TestFixture]
	public class DoubleRoundingConverterTests
	{
		[Test]
		public void Convert_StringProvided_ThrowsCastException()
		{
			var converter = new DoubleToStringConverter();

			Assert.Throws<InvalidCastException>(
				() => converter.Convert("hello", null, null, null));
		}

		[Test]
		public void Convert_Zero_ReturnsEmptyString()
		{
			var converter = new DoubleToStringConverter();

			var result = converter.Convert(0d, null, null, null);

			Assert.AreEqual("", result);
		}

		[Test]
		public void Convert_NonZero_ReturnsString()
		{
			var converter = new DoubleToStringConverter();

			var result = converter.Convert(3.14D, null, null, null);

			Assert.AreEqual("3.14", result);
		}

		[Test]
		public void ConvertBack_NonNumericString_ReturnsZero()
		{
			var converter = new DoubleToStringConverter();

			var result = converter.ConvertBack("hello", null, null, null);

			Assert.AreEqual(0, result);
		}

		[Test]
		public void ConvertBack_NumericString_ReturnsNumber()
		{
			var converter = new DoubleToStringConverter();

			var result = converter.ConvertBack("3.14", null, null, null);

			Assert.AreEqual(3.14, result);
		}
	}
}