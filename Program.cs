using System;
using System.Collections.Generic;
using System.Linq;

namespace st_petersburg
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfGames = 1000;
            var maxBudget = Math.Pow(2, 7);
            var gameScores = new List<double>();
            for (var i = 0; i < numberOfGames; i++)
            {
                gameScores.Add(SimulateStPeterParadox(maxBudget, 1));
            }
        }

        private static double SimulateStPeterParadox(double maxBudget, int round)
        {
            while (true)
            {
                var random = new Random();
                var currentPower = Math.Pow(2, round);
                if (currentPower > maxBudget) return maxBudget;

                if (random.Next(0, 1) == 1)
                    return currentPower;

                round++;
            }
        }


    }
}
