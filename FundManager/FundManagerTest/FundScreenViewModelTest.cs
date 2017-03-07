using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager.ViewModel;
using System.Collections.Generic;
using FundManager.Model;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;

namespace FundManagerTest
{
    [TestClass]
    public class FundScreenViewModelTest
    {
        [TestMethod]
        public void InstantiateFundScreenViewModel()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
        }

        [TestMethod]
        public void AllStocksPropertyInitialised()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            Assert.IsNotNull(viewmodel.AllStocks);
        }

        [TestMethod]
        public void AddNewStockInAllStocks()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            Stock newStock = new Stock();
            viewmodel.AllStocks.Add(newStock);
        }

        

        [TestMethod]
        public void AddNewEquityInAllStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Equity;
            newStock.Price = 10.200;
            newStock.Quantity = 5;
            newStock.StockName = "Equity1";
          
            viewmodel.AllStocks.Add(newStock);
            Assert.AreEqual(1, viewmodel.AllStocks.Where(c => c.StockName == "Equity1").Count());
        }

        [TestMethod]
        public void AddNewBondInAllStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();

            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Bond;
            newStock.Price = 10.200;
            newStock.Quantity = 5;
            newStock.StockName = "Bond1";
           
            viewmodel.AllStocks.Add(newStock);
            Assert.AreEqual(1, viewmodel.AllStocks.Where(c => c.StockName == "Bond1").Count());
        }

        

        [TestMethod]
        public void CalculateStockWeight()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Bond;
            newStock.Price = 100;
            newStock.Quantity = 5;
            double ExpectedStockWeight = viewmodel.CalculateStockWeight(newStock.MarketValue);
            double totalMarketValue = viewmodel.AllStocks.Sum(c => c.MarketValue);
            double stockWeight = newStock.MarketValue / 100 * totalMarketValue;
            Assert.AreEqual(ExpectedStockWeight, stockWeight);
        }

        [TestMethod]
        public void GenerateStockName_StockTypeEquity_OnePlusExsitingEquity()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();  
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Equity;
            string newEquityName = viewmodel.GenerateStockName(StockEnum.Equity);           
            int existingNoOfEquity = viewmodel.AllStocks.Where(c => c.StockType == StockEnum.Equity).Count();
            Assert.AreEqual(newEquityName, "Equity" + (existingNoOfEquity + 1).ToString());
        }

        [TestMethod]
        public void GenerateStockName_StockTypeBond_OnePlusExsitingBond()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            Stock newStock = new Stock();
            newStock.StockType = StockEnum.Bond;
            string newBondName = viewmodel.GenerateStockName(StockEnum.Bond);
            int existingNoOfBond = viewmodel.AllStocks.Where(c => c.StockType == StockEnum.Bond).Count();
            Assert.AreEqual(newBondName, "Bond" + (existingNoOfBond + 1).ToString());
        }

        public ObservableCollection<Stock> CreateAllStocks()
        {
            ObservableCollection<Stock> AllStocks = new ObservableCollection<Stock>();
            AllStocks.Add(new Stock() { StockName = "Equity1" , StockType = StockEnum.Equity});
            AllStocks.Add(new Stock() { StockName = "Equity2", StockType = StockEnum.Equity });
            AllStocks.Add(new Stock() { StockName = "Equity3", StockType = StockEnum.Equity });
            AllStocks.Add(new Stock() { StockName = "Bond1", StockType = StockEnum.Bond });
            AllStocks.Add(new Stock() { StockName = "Bond2", StockType = StockEnum.Bond });
            AllStocks.Add(new Stock() { StockName = "Bond3", StockType = StockEnum.Bond });
            return AllStocks;
        }

        [TestMethod]

        public void CanExecuteAddNewStockCommand()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            DelegateCommand command = viewmodel.AddNewStockCommand;
            viewmodel.AllStocks = new ObservableCollection<Stock>();
            command.Execute();
        }


        [TestMethod]
        public void CanInputPriceForNewStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.NewStockPrice = "100.80";
            Assert.AreEqual("100.80", viewmodel.NewStockPrice);
        }

        [TestMethod]
        public void CanInputQuantityForNewStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.NewStockQuantity = "10";
            Assert.AreEqual("10", viewmodel.NewStockQuantity);
        }

        [TestMethod]
        public void IsEquitySelectedForNewStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.IsEquitySelected = true;
            Assert.AreEqual(true, viewmodel.IsEquitySelected);
        }

        [TestMethod]
        public void IsBondSelectedForNewStock()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.IsBondSelected = true;
            Assert.AreEqual(true, viewmodel.IsBondSelected);
        }

        [TestMethod]
        public void CanAddNewStockCommand()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.AllStocks = CreateAllStocks();
            DelegateCommand command = viewmodel.AddNewStockCommand;
            viewmodel.NewStockPrice = "100.80";
            viewmodel.NewStockQuantity = "10";
            viewmodel.IsEquitySelected = true;
            command.Execute();
            Assert.AreEqual(viewmodel.AllStocks.Count(), 7);
            Assert.AreEqual(viewmodel.AllStocks[6].StockType, StockEnum.Equity);
            Assert.AreEqual(viewmodel.AllStocks[6].StockName, "Equity4");
            Assert.AreEqual(viewmodel.AllStocks[6].Price, 100.80);
            Assert.AreEqual(viewmodel.AllStocks[6].Quantity, 10);
            Assert.AreEqual(viewmodel.AllStocks[6].MarketValue, 1008);
            Assert.AreEqual(viewmodel.AllStocks[6].TransactionCost, 5.04);
            Assert.AreEqual(viewmodel.AllStocks[6].StockWeight, 0);
        }

        [TestMethod]
        public void PropertyChangeNotificationIsFired_StocksValue()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.AllStocks = CreateAllStocks();
            bool isFired = false;
            viewmodel.PropertyChanged += (sender,args) =>
            {
                if (args.PropertyName == "StocksValue")
                    isFired = true;
            };

            DelegateCommand command = viewmodel.AddNewStockCommand;
            command.Execute();
            Assert.IsTrue(isFired);
        }      

        [TestMethod]
        public void StockValues_AllStocksIsEmpty()
        {
        FundScreenViewModel viewmodel = new FundScreenViewModel();
        Assert.IsNull(viewmodel.StocksValue);
        }

        [TestMethod]
        public void StockValues_AllStocksHasValue()
        {
            FundScreenViewModel viewmodel = new FundScreenViewModel();
            viewmodel.AllStocks = CreateAllStocks();
            Assert.IsNotNull(viewmodel.StocksValue);
        }
    }
}
