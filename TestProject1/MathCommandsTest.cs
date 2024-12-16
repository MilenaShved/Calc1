using Xunit;
using Calc.MathOperations;

namespace TestProject1
{
    public class MathCommandsTest
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            var add = new Add();
            Assert.Equal(5, add.Apply(2, 3));
        }

        [Fact]
        public void Sub_ShouldReturnCorrectDifference()
        {
            var sub = new Sub();
            Assert.Equal(1, sub.Apply(3, 2));
        }

        [Fact]
        public void Mul_ShouldReturnCorrectProduct()
        {
            var mul = new Mul();
            Assert.Equal(6, mul.Apply(2, 3));
        }

        [Fact]
        public void Div_ShouldReturnCorrectQuotient()
        {
            var div = new Div();
            Assert.Equal(2, div.Apply(6, 3));
        }

        [Fact]
        public void Div_ShouldThrowExceptionOnDivisionByZero()
        {
            var div = new Div();
            Assert.Throws<DivideByZeroException>(() => div.Apply(6, 0));
        }
    }
}
