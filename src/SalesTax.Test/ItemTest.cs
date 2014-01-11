using NUnit.Framework;
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
		public void an_item_prize_is_specified_when_the_item_is_constructed(decimal prize)
		{
			new Item(prize).Prize.Should().Be.EqualTo(prize);
		}
	}
}
