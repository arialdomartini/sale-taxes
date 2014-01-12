using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
	public class DutyTaxCalculator : ITaxCalculator
	{
		public decimal CalculateOn(Item item)
		{
			var rawTax = (item.Price*5/100);
			return decimal.Round(rawTax/5, 2, MidpointRounding.ToEven)*5;
		}
	}
}
