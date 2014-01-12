using SalesTax.Items;

namespace SalesTax.TaxCalculators
{
	public interface ITaxCalculator
	{
		decimal CalculateOn(ICanBeSold item);
	}
}
