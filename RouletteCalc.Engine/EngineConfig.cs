using RouletteCalc.Utilities.Enums;

namespace RouletteCalc.Application
{
    public class EngineConfig
    {
        private decimal _baseBid = 1;
        public virtual decimal BaseBid
        {
            get { return _baseBid; }
            set
            {
                _baseBid = value;
                if (value < 0)
                    _baseBid = 0;
            }
        }

        public virtual decimal BaseBalance { get; set; }

        private readonly object _lockNOF = new object();

        private int _numberOfFields = 37;
        public virtual int NumberOfFields
        {
            get { return _numberOfFields; }
            set
            {
                lock (_lockNOF)
                {
                    _numberOfFields = value;
                    if (value < 1) // ~~!!!~~ Min value is 1
                        _numberOfFields = 1;

                    var diff = _numberOfFields - (_numberOfWiningFields + _numberOfLosingFields);
                    if (diff < 0)
                    {
                        diff += _numberOfWiningFields;
                        if (diff >= 0)
                        {
                            _numberOfWiningFields = diff;
                        }
                        else
                        {
                            _numberOfWiningFields = 0; // ~~!!!~~ diff <= 0  ----> NumberOfWiningFields = 0
                            NumberOfLosingFields += diff;
                        }
                    }
                    else
                    {
                        _numberOfWiningFields += diff;
                    }
                }
            }
        }

        private readonly object _lockNOWF = new object();

        private int _numberOfWiningFields = 18;
        public virtual int NumberOfWiningFields
        {
            get { return _numberOfWiningFields; }
            set
            {
                lock (_lockNOWF)
                {
                    if (_numberOfFields != (_numberOfLosingFields + value))
                    {
                        _numberOfFields = _numberOfLosingFields + value;
                    }

                    _numberOfWiningFields = value;

                    if (value < 0)
                    {
                        _numberOfWiningFields = 0;
                    }
                }
            }
        }

        private readonly object _lockNOLF = new object();

        private int _numberOfLosingFields = 19;
        public virtual int NumberOfLosingFields
        {
            get { return _numberOfLosingFields; }
            set
            {
                lock (_lockNOLF)
                {
                    // update number of all fields if new value is bigger
                    if (_numberOfFields != (_numberOfWiningFields + value))
                    {
                        _numberOfFields = _numberOfWiningFields + value;
                    }

                    _numberOfLosingFields = value;

                    if (value < 0)
                    {
                        _numberOfLosingFields = 0;
                    }
                }
            }
        }

        private int _numberOfGames = 1;
        public virtual int NumberOfGames
        {
            get { return _numberOfGames; }
            set
            {
                _numberOfGames = value;
                if (value < 1)
                {
                    _numberOfGames = 1;
                }
            }
        }

        public virtual MathOp WinningModifierType { get; set; } = MathOp.Mult;

        public virtual decimal WinningModifier { get; set; } = 2;

        public virtual MathOp ProgressionModifierType { get; set; } = MathOp.Mult;

        public virtual decimal ProgressionModifier { get; set; } = 2;
    }
}
