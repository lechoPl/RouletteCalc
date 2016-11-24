using RouletteCalc.Utilities.Math;

namespace RouletteCalc.Domain.ValueObjects
{
    /// <summary>
    /// Represents game state
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Represents bid of current game
        /// </summary>
        public virtual decimal Bid { get; set; }

        /// <summary>
        /// Represents total balance of current game
        /// </summary>
        public virtual decimal Balance { get; set; }

        /// <summary>
        /// Represents probability of current state of game
        /// </summary>
        public virtual Fraction Probability { get; set; }

        /// <summary>
        /// Represents number of played games from start
        /// </summary>
        public virtual int NumberOfPlayedGames { get; set; }

        /// <summary>
        /// Represents number of won games from start
        /// </summary>
        public virtual int NumberOfWon { get; set; }

        /// <summary>
        /// Represents number of defeat games from start
        /// </summary>
        public virtual int NumberOfDefeat { get; set; }
    }
}
