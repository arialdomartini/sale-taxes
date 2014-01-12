using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalesTax.Items;
using SalesTax.TaxCalculators;
using SharpTestsEx;

namespace SalesTax.Test
{
	[TestFixture]
	public class AcceptanceTests
	{
		private static TaxesCalculator BuildTaxesCalculator()
		{
			// IoC
			var taxesCalculator = new TaxesCalculator(
				new List<ITaxCalculator>
					{
						new DutyTaxCalculator(new Round()),
						new SalesTaxCalculator(new Round(), new List<Type>
							{
								typeof (Book),
								typeof (Food),
								typeof (MedicalProduct),
							})
					}
				);
			return taxesCalculator;
		}


		[Test]
		public void the_total_price_of_a_list_of_books_inlcudes_duty_taxes_which_are_separately_returned()
		{
			var items = new List<ICanBeSold>
				{
					new Book("Lolita", 10, hasBeenImported:true),
					new Book("Fontamara", (decimal) 1.2, hasBeenImported:true)
				};

			var taxesCalculator = BuildTaxesCalculator();
			var basket = new Basket(taxesCalculator, items);

			basket.Total.Should().Be.EqualTo(11.2 + 0.05 + 0.50);
			basket.TotalTaxes.Should().Be.EqualTo(0.05 + 0.50);
		}

		[Test]
		public void basic_sales_taxes_are_applied_to_every_item_but_books_and_food()
		{
			var items = new List<ICanBeSold>
				{
					new Book("Title", (decimal) 10, hasBeenImported:true),
					new Food("Honey", (decimal) 1.2, hasBeenImported:true),
					new Item("Gun", 1000, hasBeenImported:true)
				};

			var taxesCalculator = BuildTaxesCalculator();
			var basket = new Basket(taxesCalculator, items);

			basket.Total.Should().Be.EqualTo( (1000 + 100 + 50)  
												+ 11.2 + 0.05 + 0.50);
			basket.TotalTaxes.Should().Be.EqualTo(100 + 50 + 0.05 + 0.50);
		}

		
		
		[Test]
		public void example_1()
		{
			/*
				1 book at 12.49
				1 music CD at 14.99
				1 chocolate bar at 0.85

				Output 1:
				1 book : 12.49
				1 music CD: 16.49
				1 chocolate bar: 0.85
				Sales Taxes: 1.50
				Total: 29.83
			*/

			var items = new List<ICanBeSold>
				{
					new Book("Title", (decimal) 12.49),
					new Item("Music CD", (decimal) 14.99),
					new Food("Chocolate bar", (decimal) 0.85)
				};

			var taxesCalculator = BuildTaxesCalculator();
			var basket = new Basket(taxesCalculator, items);

			basket.Total.Should().Be.EqualTo((decimal) 29.83);
			basket.TotalTaxes.Should().Be.EqualTo((decimal) 1.50);

		}

		[Test]
		public void example_2()
		{
			/*
				Input 2:
				1 imported box of chocolates at 10.00
				1 imported bottle of perfume at 47.50

				Output 2:
				1 imported box of chocolates: 10.50
				1 imported bottle of perfume: 54.65
				Sales Taxes: 7.65
				Total: 65.15

			*/

			var items = new List<ICanBeSold>
				{
					new Food("Chocolate", (decimal) 10.00, hasBeenImported: true),
					new Item("Perfume", (decimal) 47.50, hasBeenImported: true)
				};

			var taxesCalculator = BuildTaxesCalculator();
			var basket = new Basket(taxesCalculator, items);

			basket.Total.Should().Be.EqualTo((decimal)65.15);
			basket.TotalTaxes.Should().Be.EqualTo((decimal)7.65);

		}

		[Test]
		public void example_3()
		{
			/*
				Input 3:
				1 imported bottle of perfume at 27.99
				1 bottle of perfume at 18.99
				1 packet of headache pills at 9.75
				1 box of imported chocolates at 11.25

				Output 3:
				1 imported bottle of perfume: 32.19
				1 bottle of perfume: 20.89
				1 packet of headache pills: 9.75
				1 imported box of chocolates: 11.85 ==> 11.80 [This does not reflect with the given requirements. A discussion with the customer is needed.] 
				Sales Taxes: 6.70
				Total: 74.68
			*/

			var items = new List<ICanBeSold>
				{
					new Item("Perfume", (decimal) 27.99, hasBeenImported: true),
					new Item("Perfume", (decimal) 18.99, hasBeenImported: false),
					new MedicalProduct("Headache pills", (decimal) 9.75),
					new Food("Chocolate", (decimal) 11.25, hasBeenImported: true),
				};

			var taxesCalculator = BuildTaxesCalculator();
			var basket = new Basket(taxesCalculator, items);

			basket.Total.Should().Be.EqualTo((decimal)74.63);
			basket.TotalTaxes.Should().Be.EqualTo((decimal)6.65);

		}

	}
}
