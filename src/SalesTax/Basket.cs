using System;
using System.Collections.Generic;
using System.Linq;

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
				return _items.Aggregate((decimal) 0, 
					(subtotal, item) => 
						subtotal + item.Price + _dutyTaxCalculator.CalculateOn(item));
			}
	    }

	    public decimal TotalTaxes
	    {
			get
			{
				return _items.Aggregate((decimal)0,
					(subtotal, item) =>
						subtotal + _dutyTaxCalculator.CalculateOn(item));
			}
	    }
    }
}
