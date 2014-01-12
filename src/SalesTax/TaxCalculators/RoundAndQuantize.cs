namespace SalesTax.TaxCalculators
{
	public class RoundAndQuantize : IRoundStrategy
	{
		private readonly decimal _step;

		public RoundAndQuantize()
		{
			_step = (decimal) 0.05;
		}

		public decimal Round(decimal value)
		{
			return decimal.Round(
				decimal.Round(value / _step) * _step, 2);
		}

	}
}
