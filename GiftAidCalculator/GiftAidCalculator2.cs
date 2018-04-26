
namespace GiftAidCalculator
{
	/// <summary>
	/// A gift aid calculator that uses a tax rate from a data store.
	/// </summary>
	public class GiftAidCalculator2
	{
		// The tax rate used in the gift aid calculation
		public decimal TaxRate => _dataStore.GetTaxRate();

		// The datastore to retrieve the tax rate from
		private readonly IDataStore _dataStore;
		
		
		public GiftAidCalculator2(IDataStore dataStore)
		{
			_dataStore = dataStore;
		}
		

		/// <summary>
		/// Calculates the gift aid for a donation amount using a retrieved tax rate.
		/// </summary>
		/// <param name="donationAmount"></param>
		/// <returns></returns>
		public decimal GiftAidAmount(decimal donationAmount)
		{
			// only retrieve tax rate once
			var taxRate = TaxRate;
			var gaRatio = taxRate / (100 - taxRate);
			return donationAmount * gaRatio;
		}
	}
}
