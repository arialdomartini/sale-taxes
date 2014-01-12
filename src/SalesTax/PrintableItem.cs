namespace SalesTax
{
	public class PrintableItem
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public decimal Tax { get; private set; }

		public PrintableItem(string name, decimal price, decimal tax)
		{
			Name = name;
			Price = price;
			Tax = tax;
		}
	}
}