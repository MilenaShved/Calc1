using System.Threading.Tasks;
using Managers;

namespace Calc.CommandsInterface
{
    public interface ICmd
    {
        Task ExecAsync(Calculator calc);
    }
}
