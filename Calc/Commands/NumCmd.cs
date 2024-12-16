using System.Threading.Tasks;
using Calc.CommandsInterface;
using Managers;

namespace Calc.Commands
{
    public class NumCmd : ICmd
    {
        private readonly double x;

        public NumCmd(double x)
        {
            this.x = x;
        }

        public async Task ExecAsync(Calculator calc)
        {
            await calc.ProcessNumAsync(x);
        }
    }
}
