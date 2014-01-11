using System;

namespace SalesTax
{
    public class Basket
    {
	    private Item _item;

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

	public class Item
	{
		private decimal _prize;

		public Item(decimal prize)
		{
			_prize = prize;
		}

		public decimal Prize
		{
			get { return _prize; }
		}
	}
}
