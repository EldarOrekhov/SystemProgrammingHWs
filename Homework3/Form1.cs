using System.Net;
using System.Numerics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FactorialTextBox.Text, out int number) && number >= 0)
            {
                resultLabel.Text = "Calculating";
                Thread factorialThread = new Thread(() => ComputeFactorial(number));
                factorialThread.Start();
            }
            else
            {
                resultLabel.Text = "Invalid input";
            } 
        }

        private void ComputeFactorial(int number)
        {
            long result = Factorial(number);
            this.Invoke((MethodInvoker)delegate { resultLabel.Text = $"Factorial: {result}"; });
        }

        private long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}

