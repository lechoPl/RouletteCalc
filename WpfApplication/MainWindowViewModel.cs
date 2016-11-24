using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
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

        public EngineConfig Config { get; private set; } = new EngineConfig();

        public IList<GameState> GridDataSource { get; set; }

        public string BaseBid
        {
            get { return Config.BaseBid.ToString(CultureInfo.InvariantCulture); }
            set
            {
                decimal result;
                if (decimal.TryParse(value, NumberStyles.Any, null, out result))
                {
                    Config.BaseBid = result;
                }
            }
        }

        public string BaseBalance
        {
            get { return Config.BaseBalance.ToString(CultureInfo.InvariantCulture); }
            set
            {
                decimal result;
                if (decimal.TryParse(value, NumberStyles.Any, null, out result))
                {
                    Config.BaseBalance = result;
                }
            }
        }

        public string NumberOfFields
        {
            get { return Config.NumberOfFields.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int result;
                if (int.TryParse(value, NumberStyles.Any, null, out result))
                {
                    if(Config.NumberOfFields != result)
                    {
                        Config.NumberOfFields = result;
                        _mainWindow.RefreshNumberOfWiningFields();
                        _mainWindow.RefreshNumberOfLosingFields();
                    }
                }
            }
        }


        public string NumberOfWiningFields
        {
            get { return Config.NumberOfWiningFields.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int result;
                if (int.TryParse(value, NumberStyles.Any, null, out result))
                {
                    if (Config.NumberOfWiningFields != result)
                    {
                        Config.NumberOfWiningFields = result;
                        _mainWindow.RefreshNumberOfFields();
                    }
                }
            }
        }


        public string NumberOfLosingFields
        {
            get { return Config.NumberOfLosingFields.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int result;
                if (int.TryParse(value, NumberStyles.Any, null, out result))
                {
                    if (Config.NumberOfLosingFields != result)
                    {
                        Config.NumberOfLosingFields = result;
                        _mainWindow.RefreshNumberOfFields();
                    }
                }
            }
        }

        public string NumberOfGames
        {
            get { return Config.NumberOfGames.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int result;
                if (int.TryParse(value, NumberStyles.Any, null, out result))
                {
                    if (Config.NumberOfGames != result)
                    {
                        Config.NumberOfGames = result;
                    }
                }
            }
        }

        public string MultiplierWinning
        {
            get { return Config.MultiplierWinning.ToString(CultureInfo.InvariantCulture); }
            set
            {
                decimal result;
                if (decimal.TryParse(value, NumberStyles.Any, null, out result))
                {
                    Config.MultiplierWinning = result;
                }
            }
        }

        public string MultiplierProgression
        {
            get { return Config.MultiplierProgression.ToString(CultureInfo.InvariantCulture); }
            set
            {
                decimal result;
                if (decimal.TryParse(value, NumberStyles.Any, null, out result))
                {
                    Config.MultiplierProgression = result;
                }
            }
        }
    }
}
