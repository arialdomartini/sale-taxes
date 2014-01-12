namespace SalesTax
{
	public interface IReceiptFormatter
	{
		string Print();
	}

	public class PlainTextReceiptFormatter : IReceiptFormatter
	{
		public string Print()
		{
			return @"Sales Taxes: 0.00
Total: 0.00";
		}
	}
}