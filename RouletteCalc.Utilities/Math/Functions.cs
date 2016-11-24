namespace RouletteCalc.Utilities.Math
{
    public static class Functions
    {
        /// <summary>
        /// Greatest common divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns greatest common divisor of two numbers</returns>
        public static dynamic GCD(dynamic a, dynamic b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
