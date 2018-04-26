using System;

namespace GiftAidCalculator
{
	/// <summary>
	/// A gift aid calculator that supplements the gift aid depending on the event type. 
	/// </summary>
	public class GiftAidCalculator4
	{
		// The tax rate used in the gift aid calculation
		public decimal TaxRate => _dataStore.GetTaxRate();

		// The datastore to retrieve the tax rate and event supplements from
		private readonly IDataStore _dataStore;
		
		
		public GiftAidCalculator4(IDataStore dataStore)
		{
			_dataStore = dataStore;
		}
		
		
		/// <summary>
		/// Calculates the gift aid for a donation amount, applying a supplementary percentage
		/// based on the provided event type.
		/// </summary>
		/// <param name="donationAmount"></param>
		/// <param name="eventType"></param>
		/// <returns></returns>
		public decimal GiftAidAmount(decimal donationAmount, string eventType = "")
		{
			// only retrieve tax rate once
			var taxRate = TaxRate;
			var gaRatio = taxRate / (100 - taxRate);
			var giftAid = donationAmount * gaRatio; 
				
			// apply event supplement
			if (!string.IsNullOrWhiteSpace(eventType))
			{							
				var eventSupplement = _dataStore.GetEventSupplementRate(eventType) / 100;					
				giftAid += giftAid * eventSupplement;
			}
			
			// use standard rounding, not default (to even)
			return Math.Round(giftAid, 2, MidpointRounding.AwayFromZero);
		}
	}
}
