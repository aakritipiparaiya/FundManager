using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace FundManagerTest
{
    [TestClass]
    public class StocksValueTest
    {
        [TestMethod]
        public void InstantiateStocksValue()
        {
            StocksValue stockValue = new StocksValue();
        }

        [TestMethod]
        public void AddStocksValueProperties()
        {
            StocksValue stockValue = new StocksValue();
            stockValue.TotalNoEquity = 10.8;
            stockValue.TotalStockWeightEquity = 10.8;
            stockValue.TotalMarketValueEquity = 10.8;
            stockValue.TotalNoBond = 10.8;
            stockValue.TotalStockWeightBond = 10.8;
            stockValue.TotalMarketValueBond = 10.8;
            stockValue.TotalNoAllStocks = 10.8;
            stockValue.TotalStockWeightAllStocks = 10.8;
            stockValue.TotalMarketValueAllStocks = 10.8;
        }

        public ObservableCollection<Stock> CreateAllStocks()
        {
            ObservableCollection<Stock> AllStocks = new ObservableCollection<Stock>();
            AllStocks.Add(new Stock() { StockName = "Equity1", StockType = StockEnum.Equity, Price=1, Quantity=1, StockWeight = 1 });
            AllStocks.Add(new Stock() { StockName = "Equity2", StockType = StockEnum.Equity, Price = 1, Quantity = 1, StockWeight = 1 });
            AllStocks.Add(new Stock() { StockName = "Equity3", StockType = StockEnum.Equity, Price = 1, Quantity = 1, StockWeight = 1 });
            AllStocks.Add(new Stock() { StockName = "Bond1", StockType = StockEnum.Bond, Price = 2, Quantity = 2, StockWeight = 2 });
            AllStocks.Add(new Stock() { StockName = "Bond2", StockType = StockEnum.Bond, Price = 2, Quantity = 2, StockWeight = 2 });
            AllStocks.Add(new Stock() { StockName = "Bond3", StockType = StockEnum.Bond, Price = 2, Quantity = 2, StockWeight = 2 });
            return AllStocks;
        }

        [TestMethod]
        public void PopulatePropertiesOfStocksValue()
        {
            ObservableCollection<Stock> AllStocks = CreateAllStocks();
            StocksValue stocks = new StocksValue();
            stocks.TotalNoEquity = AllStocks.Where(c => c.StockType == StockEnum.Equity).Sum(c => c.Quantity);
            stocks.TotalStockWeightEquity = AllStocks.Where(c => c.StockType == StockEnum.Equity).Sum(c => c.StockWeight);
            stocks.TotalMarketValueEquity = AllStocks.Where(c => c.StockType == StockEnum.Equity).Sum(c => c.MarketValue);

            stocks.TotalNoBond = AllStocks.Where(c => c.StockType == StockEnum.Bond).Sum(c => c.Quantity);
            stocks.TotalStockWeightBond = AllStocks.Where(c => c.StockType == StockEnum.Bond).Sum(c => c.StockWeight);
            stocks.TotalMarketValueBond = AllStocks.Where(c => c.StockType == StockEnum.Bond).Sum(c => c.MarketValue);

            stocks.TotalNoAllStocks = stocks.TotalNoEquity + stocks.TotalNoBond;
            stocks.TotalStockWeightAllStocks = stocks.TotalStockWeightEquity + stocks.TotalStockWeightBond;
            stocks.TotalMarketValueAllStocks = stocks.TotalMarketValueEquity + stocks.TotalMarketValueBond;

            Assert.AreEqual(stocks.TotalNoEquity, 3);
            Assert.AreEqual(stocks.TotalStockWeightEquity, 3);
            Assert.AreEqual(stocks.TotalMarketValueEquity, 3);

            Assert.AreEqual(stocks.TotalNoBond, 6);
            Assert.AreEqual(stocks.TotalStockWeightBond, 6);
            Assert.AreEqual(stocks.TotalMarketValueBond, 12);

            Assert.AreEqual(stocks.TotalNoAllStocks, 9);
            Assert.AreEqual(stocks.TotalStockWeightAllStocks, 9);
            Assert.AreEqual(stocks.TotalMarketValueAllStocks, 15);

        }
    }
}