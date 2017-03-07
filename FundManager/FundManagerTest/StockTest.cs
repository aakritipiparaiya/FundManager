using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager.Model;

namespace FundManagerTest
{
    [TestClass]
    public class StockTest
    {
        [TestMethod]
        public void InstantiateStock()
        {
            Stock newStock = new Stock();
        }

        [TestMethod]
        public void CreateNewPropertiesInStock()
        {
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Equity;
            newStock.Price = 10.200;
            newStock.Quantity = 5;
            newStock.StockName = "Equity1";
            Assert.IsNotNull(newStock);            
        }

        [TestMethod]
        public void CalculateMarketValueOfStock()
        {
            Stock newStock = new Stock();
            newStock.Price = 100;
            newStock.Quantity = 5;
            double marketValue = newStock.Price * newStock.Quantity;
            Assert.AreEqual(newStock.MarketValue, marketValue);
        }

        [TestMethod]
        public void CalculateTransactionCostOfEquityStock()
        {
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Equity;
            newStock.Price = 100;
            newStock.Quantity = 5;
            double transactionCost = newStock.MarketValue * (0.5 / 100);
            Assert.AreEqual(newStock.TransactionCost, transactionCost);
        }

        [TestMethod]
        public void CalculateTransactionCostOfBondStock()
        {
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Bond;
            newStock.Price = 100;
            newStock.Quantity = 5;
            double transactionCost = newStock.MarketValue * (2 / 100);
            Assert.AreEqual(newStock.TransactionCost, transactionCost);
        }
    }
}
