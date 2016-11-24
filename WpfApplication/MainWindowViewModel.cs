using System.Collections.Generic;
using RouletteCalc.Application;
using RouletteCalc.Domain.ValueObjects;

namespace WpfApplication
{
    public class MainWindowViewModel
    {
        private readonly MainWindow _mainWindow;

        public MainWindowViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public EngineConfig Config { get; } = new EngineConfig();

        public IList<GameState> GridDataSource { get; set; }

        public int NumberOfFields
        {
            get { return Config.NumberOfFields; }
            set
            {
                if (Config.NumberOfFields == value)
                    return;

                Config.NumberOfFields = value;
                _mainWindow.RefreshNumberOfWiningFields();
                _mainWindow.RefreshNumberOfLosingFields();
            }
        }

        public int NumberOfWiningFields
        {
            get { return Config.NumberOfWiningFields; }
            set
            {
                if (Config.NumberOfWiningFields == value)
                    return;

                Config.NumberOfWiningFields = value;
                _mainWindow.RefreshNumberOfFields();
            }
        }

        public int NumberOfLosingFields
        {
            get { return Config.NumberOfLosingFields; }
            set
            {
                if (Config.NumberOfLosingFields == value)
                    return;

                Config.NumberOfLosingFields = value;
                _mainWindow.RefreshNumberOfFields();
            }
        }
    }
}
