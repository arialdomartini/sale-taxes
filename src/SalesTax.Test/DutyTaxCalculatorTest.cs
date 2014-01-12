using NUnit.Framework;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class DutyTaxCalculatorTest
	{
		private DutyTaxCalculator _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new DutyTaxCalculator();
		}

		[TestCase(0, 0)]
		[TestCase(100, 5)]
		[TestCase(40, 2)]
		[TestCase(1, 0.05)]
		[TestCase(1.08, 0.05)]
		[TestCase(1.1, 0.05)]
		[TestCase(1.2, 0.05)]
		[TestCase(118.3, 5.90)]

		[TestCase(10, 0.5)]
		public void calculate_5percent(decimal price, decimal dutyTax)
		{
			var item = new Item(price);
			
			_sut.CalculateOn(item).Should().Be.EqualTo(dutyTax);
		}
	}
}
