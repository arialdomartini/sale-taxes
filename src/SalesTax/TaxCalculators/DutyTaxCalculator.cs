using System;
using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public class DutyTaxCalculator : ITaxCalculator
	{
		private readonly IRoundStrategy _roundStrategy;

		public DutyTaxCalculator(IRoundStrategy roundStrategy)
		{
			_roundStrategy = roundStrategy;
		}

		public decimal CalculateOn(ICanBeSold item)
		{
			if (! item.HasBeenImported)
				return 0;
			var rawTax = (item.Price*5/100);
			return _roundStrategy.Round(rawTax);
		}
	}
}
