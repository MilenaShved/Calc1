namespace Calc.CommandsInterface
{
    // интерфейс для калькулятора
    public interface ICalc
    {
        Task ProcessNumAsync(double x);
        Task ProcessOpAsync(IOp op);
        Task GoToStepAsync(int s);
        void Quit();
        Task SaveAsync();
        bool IsRunning { get; }
        bool NeedsNum { get; }
    }
}
