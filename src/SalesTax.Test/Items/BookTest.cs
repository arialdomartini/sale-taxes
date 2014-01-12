using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test.Items
{
	[TestFixture]
	public class BookTest
	{
		[Test]
		public void by_default_books_are_not_imported()
		{
			var book = new Book("title", (decimal) 100);

			book.HasBeenImported.Should().Be.False();
		}
	}
}
