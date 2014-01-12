using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalesTax.Items;
using SalesTax.TaxCalculators;
using SharpTestsEx;

namespace SalesTax.Test.TaxCalculator
{
	[TestFixture]
	public class SalesTaxesCalculatorTest
	{
		[TestCase(0,    0)]
		[TestCase(100,  10)]
		[TestCase(1,  0.1)]
		[TestCase(1.2,  0.1)]
		[TestCase(1.3,  0.15)]
		[TestCase(1.4,  0.15)]
		[TestCase(1.5,  0.15)]
		[TestCase(1.6,  0.15)]
		[TestCase(1.7,  0.15)]
		[TestCase(1.8,  0.20)]
		public void taxes_are_10percent_of_the_price(decimal price, decimal salesTax)
		{
			var exceptions = new List<Type>();
			var actual = new SalesTaxCalculator(new Round(), exceptions).CalculateOn(new Item("An item", price));

			actual.Should().Be.EqualTo(salesTax);
		}

		[Test]
		public void taxes_are_not_applied_to_books()
		{
			var exceptions = new List<Type>{ typeof(Book)};
			var actual = new SalesTaxCalculator(new Round(), exceptions).CalculateOn(new Book("Q", 100));

			actual.Should().Be.EqualTo(0);
		}

	}
}
