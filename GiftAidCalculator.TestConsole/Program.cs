using System;
using System.Collections.Generic;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		/**
		 * Internal data store implementation just for the test console.
		 */
		private class DataStore : IDataStore
		{
			private readonly Dictionary<string, decimal> _eventSupplements = new Dictionary<string, decimal>
			{
				{ "running", 5m },
				{ "swimming", 3m },
			};
			
			public decimal GetTaxRate()
			{
				return 20m;
			}

			public decimal GetEventSupplementRate(string eventType)
			{
				decimal eventSupplement;
				if (!_eventSupplements.TryGetValue(eventType, out eventSupplement))
				{
					eventSupplement = 0m;
				}
				return eventSupplement;
			}
		}
		
		
		/**
		 * Main program for the test console.
		 */
		static void Main(string[] args)
		{
			var calculator = new GiftAidCalculator4(new DataStore());
			Console.WriteLine("Using tax rate: {0}%", calculator.TaxRate);
			Console.WriteLine("Please enter donation amount:");
			var donation = decimal.Parse(Console.ReadLine());
			Console.WriteLine("Please enter event type (leave blank for none):");
			var eventType = Console.ReadLine().ToLower();
			Console.WriteLine("Gift aid is: {0}", calculator.GiftAidAmount(donation, eventType));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

	}
}
