using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class ItemTest
	{
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(2.02)]
		[TestCase(2.10)]
		[TestCase(100)]
		public void an_item_price_is_specified_when_the_item_is_constructed(decimal price)
		{
			new Item("iPod", price).Price.Should().Be.EqualTo(price);
		}
	}
}
