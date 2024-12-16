namespace Calc.Storage
{
    public class Step
    {
        public int Num { get; set; }
        public double Res { get; set; }

        public Step(int num, double res)
        {
            Num = num;
            Res = res;
        }
    }
}
