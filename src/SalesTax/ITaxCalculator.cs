namespace SalesTax
{
	public interface ITaxCalculator
	{
		decimal CalculateOn(Item item);
	}
}
