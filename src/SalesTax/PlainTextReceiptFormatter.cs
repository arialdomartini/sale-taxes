using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
	public class PlainTextReceiptFormatter : IReceiptFormatter
	{
		private readonly ICurrencyFormatter _currencyFormatter;
		private readonly List<PrintableItem> _items;
		private decimal _total;

		public PlainTextReceiptFormatter(ICurrencyFormatter currencyFormatter)
		{
			_total = 0;
			_currencyFormatter = currencyFormatter;
			_items = new List<PrintableItem>();
		}

		public string Print()
		{
			var sb = new StringBuilder();
			foreach (var item in _items)
			{
				var totalPrice = item.Price + item.Tax;
				string totalPriceString = _currencyFormatter.Format(totalPrice);
				sb.AppendLine(string.Format("{0}: {1}", item.Name, totalPriceString));
			}
			sb.AppendLine("Sales Taxes: 0.00");
			sb.AppendLine(string.Format("Total: {0}", _currencyFormatter.Format(_total)));

			return sb.ToString();
		}

		public void Add(string name, decimal price, decimal tax)
		{
			_total += price + tax;
			_items.Add(new PrintableItem(name, price, tax));
		}

	}
}