using System;

namespace SalesTax
{
    public class Basket
    {
	    private readonly Item _item;

	    public Basket(Item item)
	    {
		    _item = item;
	    }

	    public Basket()
	    {
		    _item = null;
	    }

	    public decimal Total
	    {
			get { return _item != null?_item.Prize : 0; }
	    }
    }
}
