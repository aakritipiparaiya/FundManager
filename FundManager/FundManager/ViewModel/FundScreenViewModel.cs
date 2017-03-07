using System;
using System.Collections.Generic;
using FundManager.Model;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace FundManager.ViewModel
{
    public class FundScreenViewModel :INotifyPropertyChanged
    {
       
        string newStockPrice;
        string newStockQuantity;        
        bool isEquitySelected = false;
        bool isBondSelected = false;
        Visibility newStockVisibility = Visibility.Hidden;     

        DelegateCommand addNewStockCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        //Property that displays all Fund of User
        public ObservableCollection<Stock> AllStocks
        {
            get;set;
        }        

        //Command fired on click of Add Stock
        public DelegateCommand AddNewStockCommand
        {
            get
            {
                return addNewStockCommand;
            }
        }       

        // Price for New Stock
        public string NewStockPrice
        {
            get { return newStockPrice ; }
            set
            {
                if (value != newStockPrice)
                {                    
                    newStockPrice = value;
                    NotifyPropertyChanged("NewStockPrice");
                    AddNewStockCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // Quantity for New Stock
        public string NewStockQuantity
        {
            get { return newStockQuantity; }
            set
            {
                if (value != newStockQuantity)
                {
                    newStockQuantity = value;
                    NotifyPropertyChanged("NewStockQuantity");                    
                    AddNewStockCommand.RaiseCanExecuteChanged();
                }
            }
        }

        // Property to check if stock type to be added is Equity
        public bool IsEquitySelected
        {
            get { return isEquitySelected; }
            set
            {
                if (value != isEquitySelected)
                {
                    isEquitySelected = value;

                    /* Panel to add new stock visibility depend on if Add Equity or Bond is selected.
                     * If none selected user cant add new stock */

                    if (isEquitySelected == true)
                    {
                        NewStockVisibility = Visibility.Visible;
                        NotifyPropertyChanged("NewStockVisibility");
                    }
                    if (isEquitySelected == false && IsBondSelected == false)
                    {
                        NewStockVisibility = Visibility.Hidden;
                        NotifyPropertyChanged("NewStockVisibility");
                    }
                    NotifyPropertyChanged("IsEquitySelected");
                }
            }
        }

        // Property to check if stock type to be added is Bond
        public bool IsBondSelected
        {
            get { return isBondSelected; }
            set
            {
                if (value != isBondSelected)
                {
                    isBondSelected = value;
                    /* Panel to add new stock visibility depend on if Add Equity or Bond is selected.
                    * If none selected user cant add new stock */
                    if (isBondSelected == true)
                    {
                        NewStockVisibility = Visibility.Visible;
                        NotifyPropertyChanged("NewStockVisibility");
                    }
                    if (isEquitySelected == false && IsBondSelected == false)
                    {
                        NewStockVisibility = Visibility.Hidden;
                        NotifyPropertyChanged("NewStockVisibility");
                    }
                    NotifyPropertyChanged("IsBondSelected");
                }
            }
        }      

        // Panel Visibility to add New Stock 
        public Visibility NewStockVisibility
        {
            get { return newStockVisibility; }
            set
            {
                if (value != newStockVisibility)
                {
                    newStockVisibility = value;
                    // If user decide not to add Stock, Price and Quantity should be reset if already entered
                    if (value == Visibility.Hidden)
                    {
                        NewStockPrice = null;
                        NewStockQuantity = null;
                        NotifyPropertyChanged("NewStockPrice");
                        NotifyPropertyChanged("NewStockQuantity");
                    }
                    NotifyPropertyChanged("NewStockVisibility");

                }
            }
        }


        //This will return Summary of Fund
        public StocksValue StocksValue
        {
            get
            {
                try
                {
                    if (AllStocks != null && AllStocks.Count() > 0)
                    {
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
                        return stocks;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public FundScreenViewModel()
        {
            addNewStockCommand = new DelegateCommand(() => { AddStockInList(); }, CanExecuteAddStock);
            AllStocks = new ObservableCollection<Stock>();
        }

        // This will check if User can add a new stock or not
        private bool CanExecuteAddStock()
        {
            //  Price and Quantity for new stock is mandatory.
            if (!string.IsNullOrEmpty(NewStockPrice) && !string.IsNullOrEmpty(NewStockQuantity))
                return true;
            else
                return false;
        }

        public string GenerateStockName(StockEnum stocktype)
        {
            // Stock Name gets generated from the number of occurrences of that Stock Type

            int count = AllStocks.Where(c => c.StockType == stocktype).Count();
            return (stocktype == StockEnum.Equity ? "Equity" : "Bond") + (count + 1).ToString();
        }

        public double CalculateStockWeight(double marketValue)
        {
            /* stock weight as Market Value percentage of the Total Market Value of the Fund
              (assuming Total Market Value of the Fund is the total market value of ALL funds of User)*/
            double totalMarketValue = AllStocks.Sum(c => c.MarketValue);
            return (marketValue / 100) * totalMarketValue;
        }

        public void AddStockInList()
        {
            try
            {
                Stock newstock = new Stock();
                newstock.Price = Convert.ToDouble(NewStockPrice);
                newstock.Quantity = Convert.ToInt64(NewStockQuantity);
                newstock.StockType = IsEquitySelected ? StockEnum.Equity : StockEnum.Bond;
                newstock.StockName = GenerateStockName(newstock.StockType);
                newstock.StockWeight = CalculateStockWeight(newstock.MarketValue);
                AllStocks.Add(newstock);

                /* After stock is added , Panel to add new stock is hidden,
                 Price and Quantity Textboxes are reset
                 Equity and Bond type checkboxes are also reset */
            NewStockVisibility = Visibility.Hidden;
                IsEquitySelected = false;
                IsBondSelected = false;
                NewStockPrice = null;
                NewStockQuantity = null;
                NotifyPropertyChanged("NewStockVisibility");
                NotifyPropertyChanged("StocksValue");
                NotifyPropertyChanged("NewStockPrice");
                NotifyPropertyChanged("NewStockQuantity");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}