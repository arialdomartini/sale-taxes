namespace SalesTax
{
	public class Item
	{
		private readonly decimal _prize;

		public Item(decimal prize)
		{
			_prize = prize;
		}

		public decimal Prize
		{
			get { return _prize; }
		}
	}
}