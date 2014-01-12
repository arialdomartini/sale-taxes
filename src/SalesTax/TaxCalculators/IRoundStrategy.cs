namespace SalesTax.TaxCalculators
{
	public interface IRoundStrategy
	{
		decimal Round(decimal value);
	}
}