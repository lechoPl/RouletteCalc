using System;
using RouletteCalc.Utilities.Enums;

namespace RouletteCalc.Utilities
{
    public static class MathOpHelper
    {
        public static decimal Calculate(this MathOp op, decimal a, decimal b)
        {
            switch (op)
            {
                case MathOp.Add:
                    return a + b;

                case MathOp.Mult:
                    return a*b;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
