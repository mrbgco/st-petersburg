using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.chart.Series.Clear();
            chart.Titles.Add("Simulation Result");
            this.chart.Series.Clear();
            const int numberOfGames = 10000;
            var maxBudget = Math.Pow(10, 7);
            var gameScores = new List<double>();
            var random = new Random();
            for (var i = 0; i < numberOfGames; i++)
            {
                gameScores.Add(SimulateStPeterParadox(maxBudget, 0, random));
            }

            Draw(gameScores);
        }

        private void Draw(List<double> gameScores)
        {
            for (var i = 0; i < gameScores.Count; i++)
            {
                var series = this.chart.Series.Add($"Game {i}");
                series.Points.Add(gameScores[i]);
            }

            chart.ChartAreas[0].AxisY.Title = "Money Won";
            chart.ChartAreas[0].AxisX.Title = "Game(s)";
            chart.ChartAreas[0].RecalculateAxesScale();

        }

        private static double SimulateStPeterParadox(double maxBudget, int round, Random random)
        {
            while (true)
            {
                var currentPower = Math.Pow(2, round);
                if (currentPower > maxBudget) return maxBudget;

                if (random.Next(0, 2) == 0)
                    return currentPower;

                round++;
            }
        }
    }
}
