using System;
using System.Collections.Generic;

namespace SalesTax
{
    public class Basket
    {
	    private readonly List<Item> _items;

	    public Basket(Item item)
	    {
		    _items = new List<Item>{item};
	    }

	    public Basket()
	    {
		    _items = new List<Item>();
	    }

	    public Basket(List<Item> items)
	    {
		    _items = items;
	    }

	    public decimal Total
	    {
			get { 
				decimal total = 0; 
				_items.ForEach(i => total += i.Prize);
				return total;
			}
	    }
    }
}
