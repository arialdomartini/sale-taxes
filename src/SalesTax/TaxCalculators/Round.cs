namespace SalesTax.TaxCalculators
{
	public class Round
	{
		private readonly decimal _step;

		public Round()
		{
			_step = (decimal) 0.05;
		}

		public decimal RoundAndQuantize(decimal value)
		{
			return decimal.Round(
				decimal.Round(value / _step) * _step, 2);
		}

	}
}
