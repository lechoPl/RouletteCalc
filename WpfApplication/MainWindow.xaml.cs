using System;
using System.Windows;
using System.Windows.Controls;
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

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Model == null)
                throw new NullReferenceException();

            var config = Model.Config;
            ResultDataGrid.ItemsSource = null;
            ResultDataGrid.ItemsSource = Engine.Evaluate(config); ;

            ResultDataGrid.Items.Refresh();
        }

        public void RefreshNumberOfFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfFieldsSlider.Value = Model.NumberOfFields;
        }

        public void RefreshNumberOfWiningFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfWiningFieldsSlider.Value = Model.NumberOfWiningFields;
        }

        public void RefreshNumberOfLosingFields()
        {
            if (Model == null)
                throw new NullReferenceException();

            NumberOfLosingFieldsSlider.Value = Model.NumberOfLosingFields;
        }
    }
}
