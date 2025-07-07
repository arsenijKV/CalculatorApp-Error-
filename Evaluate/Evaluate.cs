using System.Globalization;


namespace Methods

{
    public class CalculatorState
    {
        public string curentInput = "";
        public double result = 0;
        public string operation = "";
        public bool operationPending = false;

    }
    public class CalculatorLogic
    {
        private CalculatorState state;
        public CalculatorLogic(CalculatorState state)
        {
            this.state = state;
        }
        public void Evaluate()
        {
            if (state.operationPending)
            {
                if (double.TryParse(state.curentInput, CultureInfo.InvariantCulture, out double secondNumber))
                {
                    switch (state.operation)
                    {
                        case "+":
                            state.result += secondNumber;
                            break;
                        case "-":
                            state.result -= secondNumber;
                            break;
                        case "*":
                            state.result *= secondNumber;
                            break;
                        case "/":
                            if (secondNumber != 0)
                            {
                                state.result /= secondNumber;
                            }
                            else
                            {

                                state.curentInput = "Error";
                                state.operationPending = false;
                                return;
                            }
                            break;
                    }

                    state.curentInput = "";
                    state.operationPending = false;
                }
                else
                {
                    state.curentInput = "Error: Invalid input";
                }
            }
        }
    }

    public class CalculatorClear
    {
        private CalculatorState state;
        public CalculatorClear(CalculatorState state)
        {
            this.state = state;
        }
        public void ClearAll()
        {
            state.curentInput = "";
            state.result = 0;
            state.operation = "";
            state.operationPending = false;

        }

        public void ClearEntry()

        {
            if (state.curentInput.Length > 0)
            {
                state.curentInput = state.curentInput.Remove(state.curentInput.Length - 1);
            }

        }
    }
}