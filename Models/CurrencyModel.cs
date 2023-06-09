namespace TravelGuideAPI.Models
{
    public class CurrencyModel
    {
        public string BaseCurrency { get; set; }
        public Dictionary<string, double> ConversionRates { get; set; }
    }

}
