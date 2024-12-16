using Xunit;
using Calc.Commands;
using Calc.MathOperations;
using Managers;
using Calc.ScreenNotificator;
using Calc.Storage;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CalculatorCommandsTest
    {
        private readonly Calculator calculator;
        private readonly Display display;
        private readonly Session session;

        public CalculatorCommandsTest()
        {
            display = new Display();
            session = new Session();
            calculator = new Calculator(display, session);
        }

        [Fact]
        public async Task ProcessNumAsync_ShouldProcessNumberCorrectly()
        {
            await calculator.ProcessNumAsync(10);
            Assert.Equal(10, calculator.GetCurrentResult());
        }

        [Fact]
        public async Task ProcessOpAsync_ShouldApplyAdditionOperation()
        {
            await calculator.ProcessNumAsync(10);
            await calculator.ProcessOpAsync(new Add());
            await calculator.ProcessNumAsync(5);
            Assert.Equal(15, calculator.GetCurrentResult());
        }

        [Fact]
        public async Task GoToStepAsync_ShouldReturnToSpecifiedStep()
        {
            await calculator.ProcessNumAsync(10);
            await calculator.ProcessOpAsync(new Add());
            await calculator.ProcessNumAsync(5);
            await calculator.GoToStepAsync(1); // возвращаемся к первому шагу
            Assert.Equal(10, calculator.GetCurrentResult());
        }
    }
}
