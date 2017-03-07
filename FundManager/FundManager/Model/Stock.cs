namespace FundManager.Model
{
    public class Stock
    {
        public double Price { get; set; }
        public long Quantity { get; set; }
        public string StockName { get; set; }
        public StockEnum StockType { get; set; }
        public double MarketValue
        {
            get
            {
                return (double)Price * Quantity;
            }
        }       
        public double StockWeight
        {
            get;set;
        }
        public double TransactionCost
        {
            get
            {
                return MarketValue * (StockType == StockEnum.Equity ? .005 : 0.02);
            }
        }
}
}