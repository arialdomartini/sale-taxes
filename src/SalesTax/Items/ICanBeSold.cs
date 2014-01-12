namespace SalesTax.Items
{
	public interface ICanBeSold
	{
		string Name { get; }
		decimal Price { get; }
		bool HasBeenImported { get; }
	}
}