using System.Linq;
using RouletteCalc.Application;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new EngineConfig();
            var result = Engine.Evaluate(config).OrderByDescending(s => s.Balance).ThenByDescending(s => s.Probability);
        }
    }
}
