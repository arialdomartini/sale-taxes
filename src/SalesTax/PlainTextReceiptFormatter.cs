using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
	public class PlainTextReceiptFormatter : IReceiptFormatter
	{
		private readonly ICurrencyFormatter _currencyFormatter;
		private readonly List<PrintableItem> _items;

		public PlainTextReceiptFormatter(ICurrencyFormatter currencyFormatter)
		{
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
			sb.AppendLine("Total: 0.00");

			return sb.ToString();
		}

		public void Add(string name, decimal price, decimal tax)
		{
			_items.Add(new PrintableItem(name, price, tax));
		}

	}
}