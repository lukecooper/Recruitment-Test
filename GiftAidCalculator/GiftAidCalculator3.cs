using System;

namespace GiftAidCalculator
{
	/// <summary>
	/// A gift aid calculator that correcly rounds the gift aid amount.
	/// </summary>
	public class GiftAidCalculator3
	{
		// The tax rate used in the gift aid calculation
		public decimal TaxRate => _dataStore.GetTaxRate();

		// The datastore to retrieve the tax rate from
		private readonly IDataStore _dataStore;
		
		
		public GiftAidCalculator3(IDataStore dataStore)
		{
			_dataStore = dataStore;
		}
		

		/// <summary>
		/// Calculates the gift aid for a donation amount applying correct rounding.
		/// </summary>
		/// <param name="donationAmount"></param>
		/// <returns></returns>
		public decimal GiftAidAmount(decimal donationAmount)
		{
			// only retrieve tax rate once
			var taxRate = TaxRate;
			var gaRatio = taxRate / (100 - taxRate);
			
			// use standard rounding, not default (to even)
			return Math.Round(donationAmount * gaRatio, 2, MidpointRounding.AwayFromZero);
		}
	}
}
