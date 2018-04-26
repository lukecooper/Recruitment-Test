
namespace GiftAidCalculator
{
	/// <summary>
	/// A simple gift aid calculator that uses a tax rate provided at instantiation.
	/// </summary>
	public class GiftAidCalculator1
	{
		// The tax rate used in the gift aid calculation
		public decimal TaxRate { get; }

		
		public GiftAidCalculator1(decimal taxRate)
		{
			TaxRate = taxRate;
		}
		
		
		/// <summary>
		/// Calculates the gift aid amount for a donation using a fixed tax rate. 
		/// </summary>
		/// <param name="donationAmount"></param>
		/// <returns></returns>
		public decimal GiftAidAmount(decimal donationAmount)
		{
			var gaRatio = TaxRate / (100 - TaxRate);
			return donationAmount * gaRatio;
		}
	}
}
