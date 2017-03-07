using FundManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FundManager.Views
{
    /// <summary>
    /// Interaction logic for FundsScreen.xaml
    /// </summary>
    public partial class FundsScreen : Window
    {
        public FundsScreen()
        {
            FundScreenViewModel model = new FundScreenViewModel();
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            this.DataContext = model;
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            // on pressing escape, screen will close
            if (e.Key == Key.Escape)
                Close();
        }

        private void StackPanel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // If Add New Stock Panel is Visible, the grid below needs to be adjusted
            StackPanel panel = (StackPanel)sender;
            if (panel.IsVisible)
            {
                dgAllStocks.Margin = new Thickness(dgAllStocks.Margin.Left, dgAllStocks.Margin.Top + 50, dgAllStocks.Margin.Right, dgAllStocks.Margin.Bottom);
            }

            if (!panel.IsVisible)
            {
                dgAllStocks.Margin = new Thickness(dgAllStocks.Margin.Left, dgAllStocks.Margin.Top - 50, dgAllStocks.Margin.Right, dgAllStocks.Margin.Bottom);
                chkEquity.IsEnabled = true;
                chkBond.IsEnabled = true;
            }
        }

        private void checkbox_Click(object sender, RoutedEventArgs e)
        {
            /* If Equity Checkbox is checked, User should not be able to click on Bond
               and Bond Checkbox is checked, User should not be able to click on Equity */
            CheckBox box = (CheckBox)sender;
            if (box.Name == "chkEquity")
            {
                if (chkEquity.IsChecked.Value)
                {
                    chkBond.IsEnabled = false;                   
                }
                else
                {
                    chkBond.IsEnabled = true;
                }
            }
            if (box.Name == "chkBond")
            {
                if (chkBond.IsChecked.Value)
                {
                    chkEquity.IsEnabled = false;
                }
                else
                {
                    chkEquity.IsEnabled = true;
                }
            }
        }

        void DecimalTextBoxInput(object sender, TextCompositionEventArgs e)
        {
            //^[0-9]*(?:\.[0-9]*)?$
            //User can only input Numeric and decimal point for price
            var regex = new Regex(@"^(-)?[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)) 
                && !(e.Text == "-" && !String.IsNullOrEmpty(((TextBox)sender).Text) ))
                e.Handled = false;

            else
                e.Handled = true;
        }

        void NumericTextBoxInput(object sender, TextCompositionEventArgs e)
        {
              //User can only input Numeric and decimal point for price
            var regex = new Regex(@"^[0-9]*$");
            if (regex.IsMatch(e.Text))
                e.Handled = false;

            else
                e.Handled = true;
        }
    }
}
