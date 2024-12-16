using System.Threading.Tasks;
using Calc.CommandsInterface;
using Managers;

namespace Calc.Commands
{
    public class OpCmd : ICmd
    {
        private readonly IOp op;

        public OpCmd(IOp op)
        {
            this.op = op;
        }

        public async Task ExecAsync(Calculator calc)
        {
            await calc.ProcessOpAsync(op);
        }
    }
}
