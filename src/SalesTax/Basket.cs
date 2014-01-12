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
	    private IReceiptFormatter _receiptFormatter;

	    public Basket(ITaxCalculator dutyTaxCalculator, IReceiptFormatter receiptFormatter, List<ICanBeSold> items)
		{
			_dutyTaxCalculator = dutyTaxCalculator;
		    _receiptFormatter = receiptFormatter;
		    _items = items;
		}

		public Basket(ITaxCalculator dutyTaxCalculator, IReceiptFormatter receiptFormatter, ICanBeSold item) : this(dutyTaxCalculator, receiptFormatter, new List<ICanBeSold> { item }) { }

		public Basket(ITaxCalculator dutyTaxCalculator, IReceiptFormatter receiptFormatter) : this(dutyTaxCalculator, receiptFormatter, new List<ICanBeSold>()) { }

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
		    return _receiptFormatter.Print();
	    }
    }
}
