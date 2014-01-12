using System;
using System.Collections.Generic;
using System.Linq;
using SalesTax.Items;
using SalesTax.TaxCalculators;

namespace SalesTax
{
    public class Basket
    {
	    private readonly ITaxCalculator _taxCalculator;
	    private readonly List<ICanBeSold> _items;
	    private IReceiptFormatter _receiptFormatter;

	    public Basket(ITaxCalculator taxCalculator, IReceiptFormatter receiptFormatter, List<ICanBeSold> items)
		{
			_taxCalculator = taxCalculator;
		    _receiptFormatter = receiptFormatter;
		    _items = items;
		}

		public Basket(ITaxCalculator taxCalculator, IReceiptFormatter receiptFormatter, ICanBeSold item) : this(taxCalculator, receiptFormatter, new List<ICanBeSold> { item }) { }

		public Basket(ITaxCalculator taxCalculator, IReceiptFormatter receiptFormatter) : this(taxCalculator, receiptFormatter, new List<ICanBeSold>()) { }

	    public decimal Total
	    {
			get { 
				return _items.Aggregate((decimal) 0, 
					(subtotal, item) => 
						subtotal + item.Price + _taxCalculator.CalculateOn(item));
			}
	    }

	    public decimal TotalTaxes
	    {
			get
			{
				return _items.Aggregate((decimal)0,
					(subtotal, item) =>
						subtotal + _taxCalculator.CalculateOn(item));
			}
	    }

	    public string PrintReceipt()
	    {
		    foreach (var item in _items)
		    {
			    _receiptFormatter.Add(item.Name, item.Price, _taxCalculator.CalculateOn(item));
		    }
		    return _receiptFormatter.Print();
	    }
    }
}
