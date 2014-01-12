using NUnit.Framework;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class StaticCurrencyFormatterTest
	{
		[TestCase(0, "0.00")]
		[TestCase(1, "1.00")]
		[TestCase(10, "10.00")]
		[TestCase(10.01, "10.01")]
		[TestCase(10.0001, "10.00")]
		public void it_should_format_decimal_numbers_independently_to_locale(decimal value, string expected)
		{
			var sut = new StaticCurrencyFormatter();

			var actual = sut.Format(value);

			actual.Should().Be.EqualTo(expected);
		}
	}
}
