using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test.Items
{
	[TestFixture]
	public class MedicalProductTest
	{
		[Test]
		public void by_default_medicalProducts_are_not_imported()
		{
			var medicalProduct = new MedicalProduct("name", (decimal) 100);

			medicalProduct.HasBeenImported.Should().Be.False();
		}
	}
}
