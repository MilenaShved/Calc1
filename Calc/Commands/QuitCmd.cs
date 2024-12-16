using System.Threading.Tasks;
using Calc.CommandsInterface;
using Managers;

namespace Calc.Commands
{
    public class QuitCmd : ICmd
    {
        public Task ExecAsync(Calculator calc)
        {
            calc.Quit();
            return Task.CompletedTask;
        }
    }
}
