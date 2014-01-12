using System;
using System.Collections.Generic;

namespace SalesTax
{
    public class Basket
    {
	    private readonly ITaxCalculator _dutyTaxCalculator;
	    private readonly List<Item> _items;

		public Basket(ITaxCalculator dutyTaxCalculator, List<Item> items)
		{
			_dutyTaxCalculator = dutyTaxCalculator;
			_items = items;
		}

	    public Basket(ITaxCalculator dutyTaxCalculator, Item item) : this(dutyTaxCalculator, new List<Item> {item}) { }

	    public Basket(ITaxCalculator dutyTaxCalculator) : this(dutyTaxCalculator, new List<Item>()) { }

	    public decimal Total
	    {
			get { 
				decimal total = 0; 
				_items.ForEach(i => total += i.Price + _dutyTaxCalculator.CalculateOn(i));
				return total;
			}
	    }

	    public decimal TotalTaxes
	    {
			get
			{
				decimal total = 0;
				_items.ForEach(i => total += _dutyTaxCalculator.CalculateOn(i));
				return total;
			}
	    }
    }
}
