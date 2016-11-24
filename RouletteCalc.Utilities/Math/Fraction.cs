using System;
using System.Globalization;

namespace RouletteCalc.Utilities.Math
{
    /// <summary>
    /// Represents mathematic fraction
    /// </summary>
    public partial class Fraction : IComparable
    {
        public Fraction(long numerator, long denominator)
        {
            var gcd = Functions.GCD(numerator, denominator);

            _numerator = numerator / gcd;
            _denominator = denominator / gcd;
        }

        private readonly long _numerator;
        public long Numerator => _numerator;

        private readonly long _denominator;
        public long Denominator => _denominator;

        public decimal Value => ((decimal)_numerator / _denominator)*100;

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public bool Equals(Fraction f)
        {
            if (f == null)
                return false;

            return Numerator == f.Numerator && Denominator == f.Denominator;
        }

        public override bool Equals(object obj)
        {
            if(obj is Fraction)
                return Equals((Fraction) obj);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _numerator.GetHashCode() * 47 + _denominator.GetHashCode();
        }

        public int CompareTo(Fraction obj)
        {
            if (obj == null)
                return -1;

            return
                Value > obj.Value
                    ? 1
                    : Numerator == obj.Numerator && Denominator == obj.Denominator
                        ? 0
                        : -1;
        }

        public int CompareTo(object obj)
        {
            if (obj is Fraction)
                return CompareTo(obj as Fraction);

            var objAsDec = obj as decimal?;

            if (objAsDec != null)
                return decimal.Compare(Value, objAsDec.Value);

            return Equals(obj) ? 0 : -1;
        }
    }
}
