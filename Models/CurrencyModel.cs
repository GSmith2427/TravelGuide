namespace TravelGuideAPI.Models
{
    public class CurrencyModel 
    {
        public string BaseCurrency { get; set; }
        public Dictionary<string, double> ConversionRates { get; set; }
    }

    public class CurrencyData
    {
        public string Base { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }


}
