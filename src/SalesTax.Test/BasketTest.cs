using System.Collections.Generic;
using NUnit.Framework;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class BasketTest
    {
		[Test]
		public void an_empty_basket_has_total_equals_to_0()
		{
			var basket = new Basket();

			basket.Total.Should().Be.EqualTo(0);
		}

		public void a_basket_total_is_equal_to_the_price_of_its_only_item(decimal itemPrize)
		{
			var item = new Item(14);
			var basket = new Basket(item);

			basket.Total.Should().Be.EqualTo(item.Prize);
		}

		[Test]
		public void a_basket_total_is_equal_to_the_sum_of_the_items_it_contains()
		{
			var items = new List<Item>();
			items.Add(new Item(1));
			items.Add(new Item(2));
			items.Add(new Item((decimal) 2.5));
			var basket = new Basket(items);

			basket.Total.Should().Be(1 + 2 + 2.5);
		}
    }
}
