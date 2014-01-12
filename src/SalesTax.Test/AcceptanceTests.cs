using System.Collections.Generic;
using NUnit.Framework;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class AcceptanceTests
	{
		[Test]
		public void the_total_price_of_a_list_of_books_inlcudes_duty_taxes()
		{
			var items = new List<Item>
				{
					new Item(10),
					new Item((decimal) 1.2)
				};

			var total = new Basket(new DutyTaxCalculator(), items).Total;

			total.Should().Be.EqualTo(11.2 + 0.05 + 0.50);
		}
	}
}
