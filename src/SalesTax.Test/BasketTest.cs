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

    }
}
