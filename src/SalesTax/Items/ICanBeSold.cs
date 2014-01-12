namespace SalesTax.Items
{
	public interface ICanBeSold
	{
		decimal Price { get; }
		bool HasBeenImported { get; }
	}
}