namespace Calc.CommandParser
{
    public class Validator
    {
        public bool IsNum(string input) => double.TryParse(input, out _);
        public bool IsOp(string input)
        {
            string[] ops = { "+", "-", "*", "/" };
            return Array.Exists(ops, o => o == input);
        }
        public bool IsStepNum(string input) => int.TryParse(input, out _);
    }
}
