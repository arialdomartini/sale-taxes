using NUnit.Framework;
using SalesTax.TaxCalculators;
using SharpTestsEx;

namespace SalesTax.Test.TaxCalculator
{
	[TestFixture]
	class RoundTest
	{
		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(0.05, 0.05)]
		[TestCase(0.04, 0.05)]
		[TestCase(0.03, 0.05)]
		[TestCase(0.02, 0.00)]
		[TestCase(0.025, 0.00)]
		[TestCase(0.16, 0.15)]
		[TestCase(2.16, 2.15)]
		[TestCase(2.28, 2.30)]
		public void rounds_to_the_nearest_value(decimal value, decimal roundedValueExpected)
		{
			var sut = new RoundAndQuantize();

			sut.Round(value).Should().Be.EqualTo(roundedValueExpected);
		}
	}
}
