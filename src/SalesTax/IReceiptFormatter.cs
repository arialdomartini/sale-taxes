namespace SalesTax
{
	public interface IReceiptFormatter
	{
		string Print();
		void Add(string name, decimal price, decimal tax);
	}
}