namespace SalesTax.Items
{
	public class Book : ICanBeSold
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public bool HasBeenImported { get; private set; }

		public Book(string title, decimal price, bool hasBeenImported)
		{
			Name = title;
			Price = price;
			HasBeenImported = hasBeenImported;
		}

		public Book(string title, decimal price) : this(title, price, false) {}
	}
}