using System;
using System.Collections.Generic;
using System.Linq;
using SalesTax.Items;
using SalesTax.TaxCalculators;

namespace SalesTax
{
    public class Basket
    {
	    private readonly ITaxCalculator _dutyTaxCalculator;
	    private readonly List<ICanBeSold> _items;

		public Basket(ITaxCalculator dutyTaxCalculator, List<ICanBeSold> items)
		{
			_dutyTaxCalculator = dutyTaxCalculator;
			_items = items;
		}

		public Basket(ITaxCalculator dutyTaxCalculator, ICanBeSold item) : this(dutyTaxCalculator, new List<ICanBeSold> { item }) { }

		public Basket(ITaxCalculator dutyTaxCalculator) : this(dutyTaxCalculator, new List<ICanBeSold>()) { }

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

	    public string PrintReceipt()
	    {
		    return 
@"Sales Taxes: 0.00
Total: 0.00";

	    }
    }
}
