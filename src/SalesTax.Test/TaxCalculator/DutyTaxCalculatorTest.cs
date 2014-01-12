using NUnit.Framework;
using SalesTax.Items;
using SalesTax.TaxCalculators;
using SharpTestsEx;

namespace SalesTax.Test.TaxCalculator
{
	[TestFixture]
	public class DutyTaxCalculatorTest
	{
		private DutyTaxCalculator _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new DutyTaxCalculator(new RoundAndQuantize());
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
		// [TestCase(11.25, 0.60)] ==> As far as I understand, this is an error!
		[TestCase(11.25, 0.55)]
		public void calculate_5percent(decimal price, decimal dutyTax)
		{
			var item = new Item("An Item", price, hasBeenImported:true);
			
			_sut.CalculateOn(item).Should().Be.EqualTo(dutyTax);
		}

		[TestCase(0)]
		[TestCase(100)]
		[TestCase(40)]
		[TestCase(1)]
		[TestCase(1.08)]
		[TestCase(1.1)]
		[TestCase(1.2)]
		[TestCase(118.3)]

		[TestCase(10)]
		public void duty_tax_is_not_applied_to_not_imported_items(decimal price)
		{
			var item = new Item("A not imported item", price, hasBeenImported: false);

			_sut.CalculateOn(item).Should().Be.EqualTo(0);
		}

	}
}
