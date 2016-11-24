using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RouletteCalc.Application;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel Model => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9,.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Model == null)
                throw new NullReferenceException();

            var config = Model.Config;
            ResultDataGrid.ItemsSource = null;
            ResultDataGrid.ItemsSource = Engine.Evaluate(config); ;

            ResultDataGrid.Items.Refresh();
        }


        public void RefreshNumberOfWiningFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfWiningFieldsTextBox.Clear();
            NumberOfWiningFieldsTextBox.Text = Model.NumberOfWiningFields;
        }

        public void RefreshNumberOfLosingFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfLosingFieldsTextBox.Clear();
            NumberOfLosingFieldsTextBox.Text = Model.NumberOfLosingFields;
        }

        public void RefreshNumberOfFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfFieldsTextBox.Clear();
            NumberOfFieldsTextBox.Text = Model.NumberOfFields;
        }
    }
}
