using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            startingCapitalTextBox.Clear();
            goalCapitalTextBox.Clear();
            interestTextBox.Clear();
            startingCapitalTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            startingCapitalTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            int years;
            bool isValidStart = double.TryParse(startingCapitalTextBox.Text, out double startCapital);
            bool isValidEnd = double.TryParse(goalCapitalTextBox.Text, out double endCapital);
            bool isValidInterest = double.TryParse(interestTextBox.Text, out double interest);

            if (!isValidStart || !isValidEnd || !isValidInterest)
            {
                sb.AppendLine("Invalid input.");
            } 
            else if (startCapital > endCapital)
            {
                sb.AppendLine("Startkapitaal kan niet hoger zijn dan gewenst eindkapitaal.");
            }
            else
            {
                interest = 1 + (interest / 100);

                for (years = 1; startCapital <= endCapital; years++)
                {
                    startCapital *= interest;
                    sb.AppendLine($"Waarde na {years} jaren: {startCapital:c}");
                }
            }

            resultTextBox.Text = sb.ToString();
        }
    }
}
