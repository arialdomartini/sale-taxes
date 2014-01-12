using System.Collections.Generic;
using NUnit.Framework;
using SharpTestsEx;
using NSubstitute;

namespace SalesTax.Test
{
	[TestFixture]
	public class BasketTest
    {
		private ITaxCalculator _dutyTaxCalculator;

		[SetUp]
		public void SetUp()
		{
			_dutyTaxCalculator = Substitute.For<ITaxCalculator>();
		}

		[Test]
		public void an_empty_basket_has_total_equals_to_0()
		{
			var basket = new Basket(_dutyTaxCalculator);

			basket.Total.Should().Be.EqualTo(0);
		}

		[Test]
		public void a_basket_total_is_equal_to_the_price_of_its_only_item_with_duty_tax_applied()
		{
			var item = new Item(14);
			const decimal dutyTax = (decimal) 0.1;
			_dutyTaxCalculator.CalculateOn(item).Returns(dutyTax);
			var basket = new Basket(_dutyTaxCalculator, item);

			basket.Total.Should().Be.EqualTo(item.Price + dutyTax);
		}

		[Test]
		public void a_basket_total_is_equal_to_the_sum_of_the_items_it_contains_duty_tax_applied()
		{
			// given
			
			var item1 = new Item(14);
			const decimal dutyTax1 = (decimal)0.1;
			
			var item2 = new Item(140);
			const decimal dutyTax2 = (decimal)0.4;

			_dutyTaxCalculator.CalculateOn(item1).Returns(dutyTax1);
			_dutyTaxCalculator.CalculateOn(item2).Returns(dutyTax2);

			var basket = new Basket(_dutyTaxCalculator, new List<Item> {item1, item2});

			// when
			var total = basket.Total;

			// then
			total.Should().Be(item1.Price + dutyTax1 + item2.Price + dutyTax2);
		}
    }
}
