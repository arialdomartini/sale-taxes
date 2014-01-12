namespace SalesTax.Items
{
	public class Item : ICanBeSold
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public bool HasBeenImported { get; private set; }

		public Item(string name, decimal price, bool hasBeenImported)
		{
			Name = name;
			Price = price;
			HasBeenImported = hasBeenImported;
		}

		public Item(string name, decimal price) : this(name, price, false) { }
	}
}