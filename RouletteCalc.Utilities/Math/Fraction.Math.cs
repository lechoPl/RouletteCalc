namespace RouletteCalc.Utilities.Math
{
    public partial class Fraction
    {
        /// <summary>
        /// Invert(a/b) = b/c
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Fraction Invert()
        {
            return new Fraction(numerator: Denominator, denominator: Numerator);
        }

        /// <summary>
        /// Invert(a/b) = b/c
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Fraction Invert(Fraction x)
        {
            return x.Invert();
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Denominator + y.Numerator * x.Denominator, x.Denominator * y.Denominator);
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Denominator - y.Numerator * x.Denominator, x.Denominator * y.Denominator);
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            return x * y.Invert();
        }
    }
}
