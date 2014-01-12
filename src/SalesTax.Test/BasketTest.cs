using System.Collections.Generic;
using NUnit.Framework;
using SalesTax.Items;
using SalesTax.TaxCalculators;
using SharpTestsEx;
using NSubstitute;

namespace SalesTax.Test
{
	[TestFixture]
	public class BasketTest
    {
		private ITaxCalculator _taxCalculator;
		private IReceiptFormatter _receiptFormatter;

		[SetUp]
		public void SetUp()
		{
			_taxCalculator = Substitute.For<ITaxCalculator>();
			_receiptFormatter = Substitute.For<IReceiptFormatter>();
		}

		[Test]
		public void an_empty_basket_has_total_equals_to_0()
		{
			var basket = new Basket(_taxCalculator, _receiptFormatter);

			basket.Total.Should().Be.EqualTo(0);
		}
		
		[Test]
		public void total_taxes_for_an_empty_basket_is_0()
		{
			var basket = new Basket(_taxCalculator, _receiptFormatter);

			basket.TotalTaxes.Should().Be.EqualTo(0);
		}

		[Test]
		public void a_basket_total_is_equal_to_the_price_of_its_only_item_with_all_taxes_applied()
		{
			var item = new Item("generic item", 14);
			const decimal tax = (decimal) 0.1;
			_taxCalculator.CalculateOn(item).Returns(tax);
			var basket = new Basket(_taxCalculator, _receiptFormatter, item);

			basket.Total.Should().Be.EqualTo(item.Price + tax);
		}

		[Test]
		public void a_basket_returns_the_applied_taxes_to_its_only_items()
		{
			var item = new Item("generic item", 14);
			const decimal dutyTax = (decimal)0.1;
			_taxCalculator.CalculateOn(item).Returns(dutyTax);
			var basket = new Basket(_taxCalculator, _receiptFormatter, item);

			basket.TotalTaxes.Should().Be.EqualTo(dutyTax);
		}

		[Test]
		public void a_basket_total_is_equal_to_the_sum_of_the_items_it_contains_with_all_the_taxes_applied()
		{
			// given
			var item1 = new Item("generic item", 14);
			var item2 = new Item("generic item", 140);

			_taxCalculator.CalculateOn(item1).Returns((decimal)0.1);
			_taxCalculator.CalculateOn(item2).Returns((decimal)0.4);

			var basket = new Basket(_taxCalculator, _receiptFormatter, new List<ICanBeSold> { item1, item2 });

			// when
			var total = basket.Total;

			// then
			total.Should().Be(item1.Price + (decimal)0.1 + item2.Price + (decimal)0.4);
		}

		[Test]
		public void total_taxes_are_the_sum_of_the_taxes_of_each_item()
		{
			// given
			var item1 = new Item("generic item", 14);
			var item2 = new Item("generic item", 140);

			_taxCalculator.CalculateOn(item1).Returns((decimal)0.1);
			_taxCalculator.CalculateOn(item2).Returns((decimal)0.4);

			var basket = new Basket(_taxCalculator, _receiptFormatter, new List<ICanBeSold> { item1, item2 });

			// when
			var totalTaxes = basket.TotalTaxes;

			// then
			totalTaxes.Should().Be((decimal)0.1 + (decimal)0.4);
		}

		[Test]
		public void basket_should_delegate_to_its_receipt_formatter_the_printing_of_receipt()
		{
			var basket = new Basket(_taxCalculator, _receiptFormatter);

			basket.PrintReceipt();

			_receiptFormatter.Received().Print();
		}
		

		[Test]
		public void basket_should_load_its_receipt_formatter_with_its_items()
		{
			const decimal tax1 = (decimal)1;
			var item1 = new Item("foo", 10);

			const decimal tax2 = (decimal)2.99;
			var item2 = new Item("bar", 100);

			var items = new List<ICanBeSold>
				{
					item1,
					item2
				};
			_taxCalculator.CalculateOn(item1).Returns(tax1);
			_taxCalculator.CalculateOn(item2).Returns(tax2);
			var basket = new Basket(_taxCalculator, _receiptFormatter, items);

			basket.PrintReceipt();

			_receiptFormatter.Received().Add(item1.Name, item1.Price, tax1);
			_receiptFormatter.Received().Add(item2.Name, item2.Price, tax2);
		}
		
    }
}
