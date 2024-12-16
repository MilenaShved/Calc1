using System;
using System.Threading.Tasks;
using Calc.Storage;

namespace Calc.ScreenNotificator
{
    public class Display
    {
        public Task ShowUsageAsync()
        {
            Console.WriteLine("usage");
            Console.WriteLine("> ввод числа");
            Console.WriteLine("@ ввод операции");
            Console.WriteLine("операции + - * /");
            Console.WriteLine("#номер шага для возврата");
            Console.WriteLine("q выход");
            Console.WriteLine();
            return Task.CompletedTask;
        }

        public Task ShowResultAsync(Step step)
        {
            Console.WriteLine($"#{step.Num} = {step.Res}");
            return Task.CompletedTask;
        }

        public Task ShowErrorAsync(string msg)
        {
            Console.WriteLine($"ошибка {msg}");
            return Task.CompletedTask;
        }

        public Task ShowPromptAsync(string prompt)
        {
            Console.Write($"{prompt} ");
            return Task.CompletedTask;
        }
    }
}
