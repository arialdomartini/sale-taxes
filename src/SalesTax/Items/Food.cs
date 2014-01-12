namespace SalesTax.Items
{
	public class Food : ICanBeSold
	{
		public decimal Price { get; private set; }
		public bool HasBeenImported { get; private set; }
		public string Name { get; private set; }

		public Food(string name, decimal price, bool hasBeenImported)
		{
			Name = name;
			Price = price;
			HasBeenImported = hasBeenImported;
		}

		public Food(string name, decimal price) : this(name, price, false) {}
	}
}