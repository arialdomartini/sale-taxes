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

    }
}
