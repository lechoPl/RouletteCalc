﻿using System.Collections.Generic;
using System.Linq;
using RouletteCalc.Domain.ValueObjects;
using RouletteCalc.Utilities.Math;

namespace RouletteCalc.Application
{
    public static class Engine
    {
        public static IEnumerable<GameState> Evaluate(EngineConfig config)
        {
            var startState = CreatStartState(config);

            var queue = new Queue<GameState>();
            queue.Enqueue(startState);

            var result = new List<GameState>();

            while (queue.Any())
            {
                var state = queue.Dequeue();

                var stateAfterLose = GetStateAfterLose(config, state);
                if (stateAfterLose.NumberOfPlayedGames == config.NumberOfGames)
                    result.Add(stateAfterLose);
                else
                    queue.Enqueue(stateAfterLose);

                var stateAfterWin = GetStateAfterWin(config, state);
                if (stateAfterWin.NumberOfPlayedGames == config.NumberOfGames)
                    result.Add(stateAfterWin);
                else
                    queue.Enqueue(stateAfterWin);
            }

            return result;
        }

        private static GameState CreatStartState(EngineConfig config)
        {
            return new GameState
            {
                Balance = config.BaseBalance,
                Bid = config.BaseBid,
                NumberOfPlayedGames = 0,
                Probability = new Fraction(1, 1),
            };
        }

        private static GameState GetStateAfterLose(EngineConfig config, GameState baseSate)
        {
            return new GameState()
            {
                Balance = baseSate.Balance - baseSate.Bid,
                Bid = baseSate.Bid * config.MultiplierProgression,
                NumberOfPlayedGames = baseSate.NumberOfPlayedGames + 1,
                Probability = baseSate.Probability * new Fraction(config.NumberOfLosingFields, config.NumberOfFields)
            };
        }

        private static GameState GetStateAfterWin(EngineConfig config, GameState baseSate)
        {
            return new GameState()
            {
                Balance = baseSate.Balance + baseSate.Bid * config.MultiplierWinning,
                Bid = config.BaseBid,
                NumberOfPlayedGames = baseSate.NumberOfPlayedGames + 1,
                Probability = baseSate.Probability * new Fraction(config.NumberOfWiningFields, config.NumberOfFields)
            };
        }
    }
}