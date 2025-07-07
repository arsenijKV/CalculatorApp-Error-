using NUnit.Framework;
using Methods;

namespace CalculatorApp.Tests
{
    public class CalculatorLogicTests
    {
        private CalculatorState state;
        private CalculatorLogic logic;

        [SetUp]
        public void Setup()
        {
            state = new CalculatorState();
            logic = new CalculatorLogic(state);
        }

        [Test]
        public void Addition_WorksCorrectly()
        {
            state.result = 5;
            state.curentInput = "10";
            state.operation = "+";
            state.operationPending = true;

            logic.Evaluate();

            Assert.That(state.result, Is.EqualTo(15));
        }

        [Test]
        public void Division_ByZero_SetsError()
        {
            state.result = 10;
            state.curentInput = "0";
            state.operation = "/";
            state.operationPending = true;

            logic.Evaluate();

            Assert.That(state.curentInput, Is.EqualTo("Error"));
        }

        [Test]
        public void InvalidInput_SetsError()
        {
            state.result = 5;
            state.curentInput = "abc";
            state.operation = "*";
            state.operationPending = true;

            logic.Evaluate();

            Assert.That(state.curentInput.StartsWith("Error"), Is.True);
        }
    }
}