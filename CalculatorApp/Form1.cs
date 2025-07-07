using Methods;
using System;
using System.Globalization;

namespace CalculatorApp
{

    public partial class Form1 : Form
    {
        private CalculatorState state;
        private CalculatorLogic logic;
        private CalculatorClear clear;
        public Form1()
        {
            InitializeComponent();
            state = new CalculatorState();
            logic = new CalculatorLogic(state);
            clear = new CalculatorClear(state);
        }


        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            state.curentInput += button.Text;
            textBox1.Text = state.curentInput;

        }
        private void button_Equals_click(object sender, EventArgs e)
        {

            logic.Evaluate();
            textBox1.Text = state.result.ToString();

        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear.ClearAll();
            textBox1.Text = "";

        }

        private void button_ClearEntery_click(object sender, EventArgs e)
        {
            clear.ClearEntry();
            textBox1.Text = state.curentInput;
        }

        private void button_operation_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(state.curentInput))
            {
                if (double.TryParse(state.curentInput, CultureInfo.InvariantCulture, out double firstNumber))
                {
                    state.result = firstNumber;
                    state.operation = button.Text;
                    state.operationPending = true;
                    state.curentInput = "";
                }
                else
                {
                    textBox1.Text = "Error: Invalid input";
                }
            }
            else { textBox1.Text = "Error: Invalid input"; }

        }
    }
}


