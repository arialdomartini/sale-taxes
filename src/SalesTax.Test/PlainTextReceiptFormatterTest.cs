using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SalesTax.Items;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class PlainTextReceiptFormatterTest
	{
		private PlainTextReceiptFormatter _sut;
		private ICurrencyFormatter _currencyFormatter;

		[SetUp]
		public void SetUp()
		{
			_currencyFormatter = Substitute.For<ICurrencyFormatter>();
			_sut = new PlainTextReceiptFormatter(_currencyFormatter);
		}

		[Test]
		public void an_empty_receipt_should_have_total_and_taxes_0()
		{
			_currencyFormatter.Format((decimal)0.00).Returns("0.00");
		
			var actual = _sut.Print();
			
			actual.Should().Contain("Sales Taxes: 0.00");
			actual.Should().Contain("Total: 0.00");
		}

		[Test]
		public void a_receipt_should_list_items()
		{
			_sut.Add("Cocco Bill", 10, 3);
			_currencyFormatter.Format((decimal) 13.00).Returns("13.00");
			var actual = _sut.Print();

			actual.Should().Contain("Cocco Bill: 13.00");
		}

		[Test]
		public void a_receipt_should_list_the_sum_of_prices()
		{
			_sut.Add("Cocco Bill1", 10, 3);
			_sut.Add("Cocco Bill2", 10, 3);
			_currencyFormatter.Format((decimal)13.00).Returns("13.00");
			_currencyFormatter.Format((decimal)26.00).Returns("26.00");
			var actual = _sut.Print();

			actual.Should().Contain("Total: 26.00");
		}
	}
}
