namespace FundManager.Model
{
    // model for Summary of Funds
    public class StocksValue
    {
        public double TotalMarketValueAllStocks { get; set; }
        public double TotalMarketValueBond { get; set; }
        public double TotalMarketValueEquity { get; set; }
        public double TotalNoAllStocks { get; set; }
        public double TotalNoBond { get; set; }
        public double TotalNoEquity { get; set; }
        public double TotalStockWeightAllStocks { get; set; }
        public double TotalStockWeightBond { get; set; }
        public double TotalStockWeightEquity { get; set; }
    }
}