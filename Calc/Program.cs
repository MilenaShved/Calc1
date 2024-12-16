using System;
using System.Threading.Tasks;
using Managers;
using Calc.Commands;
using Calc.ScreenNotificator;
using Calc.Storage;
using Calc.CommandParser;

namespace MyCalc
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var disp = new Display();
            var sess = new Session();
            var Calculator = new Calculator(disp, sess);
            var parser = new Parser();

            await disp.ShowUsageAsync();

            while (Calculator.IsRunning)
            {
                try
                {
                    string prompt = Calculator.NeedsNum ? ">" : "@:";
                    await disp.ShowPromptAsync(prompt);
                    string input = Console.ReadLine();

                    if (input == null)
                    {
                        await disp.ShowErrorAsync("ввод не может быть пустым");
                        continue;
                    }

                    var cmd = await parser.ParseAsync(input, Calculator.NeedsNum);
                    await cmd.ExecAsync(Calculator);
                }
                catch (Exception ex)
                {
                    await disp.ShowErrorAsync(ex.Message);
                }
            }

            await Calculator.SaveAsync();
        }
    }
}
