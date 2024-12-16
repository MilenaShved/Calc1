using System;
using System.Threading.Tasks;
using Calc.Commands;
using Calc.CommandsInterface;
using Calc.MathOperations;

namespace Calc.CommandParser
{
    public class Parser
    {
        public Task<ICmd> ParseAsync(string input, bool needsNum)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("ввод не может быть пустым");

            input = input.Trim();

            if (needsNum)
            {
                // Ожидается число
                if (double.TryParse(input, out double x))
                {
                    return Task.FromResult<ICmd>(new NumCmd(x));
                }
                else
                {
                    throw new FormatException("неверный операнд");
                }
            }
            else
            {
                // Ожидается операция
                if (input.StartsWith("#"))
                {
                    string stepStr = input.Substring(1).Trim();
                    if (int.TryParse(stepStr, out int s))
                    {
                        return Task.FromResult<ICmd>(new GotoCmd(s));
                    }
                    else
                    {
                        throw new FormatException("неверный номер шага");
                    }
                }
                else if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    return Task.FromResult<ICmd>(new QuitCmd());
                }
                else
                {
                    IOp op = input switch
                    {
                        "+" => new Add(),
                        "-" => new Sub(),
                        "*" => new Mul(),
                        "/" => new Div(),
                        _ => throw new InvalidOperationException("неизвестная операция")
                    };
                    return Task.FromResult<ICmd>(new OpCmd(op));
                }
            }
        }
    }
}
