using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test.Items
{
	[TestFixture]
	public class FoodTest
	{
		[Test]
		public void by_default_food_is_not_imported()
		{
			var book = new Food("name", (decimal) 100);

			book.HasBeenImported.Should().Be.False();
		}
	}
}
