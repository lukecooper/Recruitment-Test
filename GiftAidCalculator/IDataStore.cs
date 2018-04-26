namespace GiftAidCalculator
{
    /**
     * Data store interface for retrieving a tax rate and supplement rate.
     */
    public interface IDataStore
    {
        // Retrieve the current tax rate
        decimal GetTaxRate();
        
        // Retrieve the supplement rate for the given event type
        decimal GetEventSupplementRate(string eventType);
    }
}