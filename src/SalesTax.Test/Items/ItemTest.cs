using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test.Items
{
	[TestFixture]
	public class ItemTest
	{
		[Test]
		public void by_default_itemss_are_not_imported()
		{
			var item = new Item("name", (decimal) 100);

			item.HasBeenImported.Should().Be.False();
		}
	}
}
