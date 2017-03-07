using FundManager.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FundManager
{
    public class StockNameHighlightConverter : IMultiValueConverter
    {

        // This Converter is used to highligh Stock Name as Red for any Stocks whose Market Value < 0
        // or Transaction Cost > Tolerance where Tolerance = 100,000 when Stock Type is "Bond" or
        // Tolerance = 200,000 when Stock Type is "Equity";
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                double marketValue, transactionCost, tolerance;
                marketValue = Double.TryParse(values[0].ToString(), out marketValue) ? marketValue : 0;
                transactionCost = Double.TryParse(values[1].ToString(), out transactionCost) ? transactionCost : 0;
                StockEnum type = (StockEnum)values[2];
                if (type == StockEnum.Bond)
                {
                    tolerance = 100000;
                }
                else
                {
                    tolerance = 200000;
                }
                if (marketValue < 0 || transactionCost > tolerance)
                {
                    return Brushes.Red;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}