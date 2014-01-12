using System;
using System.Collections.Generic;
using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public class SalesTaxCalculator : ITaxCalculator
	{
		private readonly IRoundStrategy _roundStrategy;
		private readonly List<Type> _exceptions;

		public SalesTaxCalculator(IRoundStrategy roundStrategy, List<Type> exceptions)
		{
			_roundStrategy = roundStrategy;
			_exceptions = exceptions;
		}

		public decimal CalculateOn(ICanBeSold item)
		{
			var mustNotBeApplied = _exceptions.Exists(c => item.GetType() == c);
			if (mustNotBeApplied)
				return 0;

			var rawTax = (item.Price * 10 / 100);
			return _roundStrategy.Round(rawTax);
		}
	}
}