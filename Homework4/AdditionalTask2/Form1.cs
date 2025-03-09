using System;
using System.Net;
using System.Numerics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<(string Name, int Time)> results = new List<(string, int)>();
        private ProgressBar[] progressBars;
        private bool raceInProgress = false;
        public Form1()
        {
            InitializeComponent();
            progressBars = new ProgressBar[] { progressBar1, progressBar2, progressBar3, progressBar4, progressBar5 };
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (raceInProgress) return;
            raceInProgress = true;
            StartButton.Enabled = false;
            ResultsListBox.Items.Clear();
            results.Clear();

            foreach (var bar in progressBars)
            {
                bar.Value = 0;
            }

            var tasks = new List<Task>();

            for (int i = 0; i < progressBars.Length; i++)
            {
                int horseNumber = i + 1;
                tasks.Add(RunHorse(progressBars[i], $"Лошадь {horseNumber}"));
            }

            await Task.WhenAll(tasks);
            ShowResults();
            StartButton.Enabled = true;
            raceInProgress = false;
        }
        private async Task RunHorse(ProgressBar bar, string horseName)
        {
            int time = 0;
            while (bar.Value < bar.Maximum)
            {
                await Task.Delay(300);
                bar.Invoke((MethodInvoker)(() => bar.Value = Math.Min(bar.Value + random.Next(5, 15), bar.Maximum)));
                time++;
            }
            results.Add((horseName, time));
        }

        private void ShowResults()
        {
            var sortedResults = results.OrderBy(r => r.Time).ToList();
            for (int i = 0; i < sortedResults.Count; i++)
            {
                ResultsListBox.Items.Add($"{i + 1} {sortedResults[i].Name} Время: {sortedResults[i].Time}");
            }
        }
    }
}