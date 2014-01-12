using System.Collections.Generic;
using System.Linq;
using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public class TaxesCalculator : ITaxCalculator
	{
		private readonly List<ITaxCalculator> _taxCalculators;

		public TaxesCalculator(List<ITaxCalculator> taxCalculators)
		{
			_taxCalculators = taxCalculators;
		}

		public decimal CalculateOn(ICanBeSold item)
		{
			return _taxCalculators.Aggregate((decimal)0, (subtotal, calculator) => subtotal + calculator.CalculateOn(item));
		}
	}
}