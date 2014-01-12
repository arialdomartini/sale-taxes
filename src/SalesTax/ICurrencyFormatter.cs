namespace SalesTax
{
	public interface ICurrencyFormatter
	{
		string Format(decimal value);
	}

	public class StaticCurrencyFormatter : ICurrencyFormatter
	{
		public string Format(decimal value)
		{
			return value.ToString("0.00").Replace(",", ".");
		}
	}
}