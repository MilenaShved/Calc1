using System.Threading.Tasks;
using Calc.CommandsInterface;
using Managers;

namespace Calc.Commands
{
    public class GotoCmd : ICmd
    {
        private readonly int step;

        public GotoCmd(int step)
        {
            this.step = step;
        }

        public async Task ExecAsync(Calculator calc)
        {
            await calc.GoToStepAsync(step);
        }
    }
}
