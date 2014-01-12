namespace SalesTax
{
	public class Item
	{
		private readonly decimal _price;

		public Item(decimal price)
		{
			_price = price;
		}

		public decimal Price
		{
			get { return _price; }
		}
	}
}