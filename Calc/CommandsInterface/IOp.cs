namespace Calc.CommandsInterface
{
    public interface IOp
    {
        double Apply(double a, double b);
        string Sym { get; }
    }
}
