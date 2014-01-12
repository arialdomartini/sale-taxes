using System;
using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public class DutyTaxCalculator : ITaxCalculator
	{
		private readonly Round _round;

		public DutyTaxCalculator(Round round)
		{
			_round = round;
		}

		public decimal CalculateOn(ICanBeSold item)
		{
			if (! item.HasBeenImported)
				return 0;
			var rawTax = (item.Price*5/100);
			return _round.RoundAndQuantize(rawTax);
		}
	}
}
