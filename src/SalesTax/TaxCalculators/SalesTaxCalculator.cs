using System;
using System.Collections.Generic;
using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public class SalesTaxCalculator : ITaxCalculator
	{
		private readonly Round _round;
		private readonly List<Type> _exceptions;

		public SalesTaxCalculator(Round round, List<Type> exceptions)
		{
			_round = round;
			_exceptions = exceptions;
		}

		public decimal CalculateOn(ICanBeSold item)
		{
			var mustNotBeApplied = _exceptions.Exists(c => item.GetType() == c);
			if (mustNotBeApplied)
				return 0;

			var rawTax = (item.Price * 10 / 100);
			return decimal.Round(rawTax / 5, 2, MidpointRounding.ToEven) * 5;

		}
	}
}