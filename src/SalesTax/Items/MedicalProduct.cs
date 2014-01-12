namespace SalesTax.Items
{
	public class MedicalProduct : ICanBeSold
	{
		public decimal Price { get; private set; }
		public bool HasBeenImported { get; private set; }
		public string Name { get; private set; }

		public MedicalProduct(string name, decimal price, bool hasBeenImported)
		{
			Name = name;
			Price = price;
			HasBeenImported = hasBeenImported;
		}

		public MedicalProduct(string name, decimal price) : this(name, price, false) {}
	}
}