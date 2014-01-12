using System.Collections.Generic;
using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class PlainTextReceiptFormatterTest
	{
		private PlainTextReceiptFormatter _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new PlainTextReceiptFormatter();
		}
		[Test]
		public void an_empty_receipt_should_have_total_and_taxes_0()
		{

			var actual = _sut.Print();

			actual.Should().Contain("Sales Taxes: 0.00");
			actual.Should().Contain("Total: 0.00");
		}
	}
}
