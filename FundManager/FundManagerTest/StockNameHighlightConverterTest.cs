using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager;
using System.Windows.Data;
using FundManager.Model;
using System.Windows.Media;

namespace FundManagerTest
{
    [TestClass]
    public class StockNameHighlightConverterTest
    {
        [TestMethod]
        public void InstantiateStockNameHighlightConverter()
        {
            StockNameHighlightConverter converter = new StockNameHighlightConverter();
        }

        [TestMethod]
        public void InstantiateasTypeIMultiValueConverter()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
        }

        [TestMethod]
        public void IfValuePassedIsNull_ReturnNull()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            object returnValue = converter.Convert(null, null, null, null);
            Assert.IsNull(returnValue);
        }

        [TestMethod]
        public void MarketValueLessThan0_ReturnRedBrush()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            string strMarketValue = "-10";
            string strTransactionCost = "10";
            StockEnum strStocktype = StockEnum.Equity;
            object[] values = new object[3];
            values[0] = strMarketValue;
            values[1] = strTransactionCost;
            values[2] = strStocktype;            
            Double marketValue = Double.TryParse(values[0].ToString(), out marketValue) ? marketValue : 0;            
            object returnValue = converter.Convert(values, null, null, null);
            Assert.AreEqual(marketValue, -10);
            Assert.AreEqual(returnValue, Brushes.Red );
        }

        [TestMethod]
        public void TransactionCostGreaterThanTolerance_Bond_ReturnRedBrush()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            string strMarketValue = "10";
            string strTransactionCost = "200000";
            StockEnum strStocktype = StockEnum.Bond;
            object[] values = new object[3];
            values[0] = strMarketValue;
            values[1] = strTransactionCost;
            values[2] = strStocktype;
            Double transactionCost = Double.TryParse(values[1].ToString(), out transactionCost) ? transactionCost : 0;
            object returnValue = converter.Convert(values, null, null, null);           
            Assert.AreEqual(returnValue, Brushes.Red);
        }

        [TestMethod]
        public void TransactionCostLessThanTolerance_Bond_ReturnRedBrush()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            string strMarketValue = "10";
            string strTransactionCost = "50000";
            StockEnum strStocktype = StockEnum.Bond;
            object[] values = new object[3];
            values[0] = strMarketValue;
            values[1] = strTransactionCost;
            values[2] = strStocktype;
            Double transactionCost = Double.TryParse(values[1].ToString(), out transactionCost) ? transactionCost : 0;
            object returnValue = converter.Convert(values, null, null, null);
            Assert.IsNull(returnValue);
        }

        [TestMethod]
        public void TransactionCostGreaterThanTolerance_Equity_ReturnRedBrush()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            string strMarketValue = "10";
            string strTransactionCost = "250000";
            StockEnum strStocktype = StockEnum.Equity;
            object[] values = new object[3];
            values[0] = strMarketValue;
            values[1] = strTransactionCost;
            values[2] = strStocktype;
            Double transactionCost = Double.TryParse(values[1].ToString(), out transactionCost) ? transactionCost : 0;
            object returnValue = converter.Convert(values, null, null, null);
            Assert.AreEqual(returnValue, Brushes.Red);
        }

        [TestMethod]
        public void TransactionCostLessThanTolerance_Equity_ReturnRedBrush()
        {
            IMultiValueConverter converter = new StockNameHighlightConverter();
            string strMarketValue = "10";
            string strTransactionCost = "20000";
            StockEnum strStocktype = StockEnum.Equity;
            object[] values = new object[3];
            values[0] = strMarketValue;
            values[1] = strTransactionCost;
            values[2] = strStocktype;
            Double transactionCost = Double.TryParse(values[1].ToString(), out transactionCost) ? transactionCost : 0;
            object returnValue = converter.Convert(values, null, null, null);
            Assert.IsNull(returnValue);
        }


    }
}
