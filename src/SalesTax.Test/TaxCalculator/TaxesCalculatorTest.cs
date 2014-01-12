using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SalesTax.Items;
using SalesTax.TaxCalculators;
using SharpTestsEx;

namespace SalesTax.Test.TaxCalculator
{
	[TestFixture]
	public class TaxesCalculatorTest
	{
		[Test]
		public void it_applies_all_the_underlying_tax_calculations()
		{
			var item = Substitute.For<ICanBeSold>();
			var taxCalculator1 = Substitute.For<ITaxCalculator>();
			var taxCalculator2 = Substitute.For<ITaxCalculator>();
			
			taxCalculator1.CalculateOn(item).Returns((decimal)10);
			taxCalculator2.CalculateOn(item).Returns((decimal)20); 
			var sut = new TaxesCalculator(new List<ITaxCalculator> {taxCalculator1, taxCalculator2});

			var total = sut.CalculateOn(item);

			total.Should().Be.EqualTo(30);
		}
	}
}
