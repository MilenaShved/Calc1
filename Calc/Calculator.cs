using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calc.CommandsInterface;
using Calc.ScreenNotificator;
using Calc.Storage;

namespace Managers
{
    public class Calculator
    {
        private readonly List<Step> steps = new List<Step>();
        private readonly Display disp;
        private readonly Session sess;
        private bool run = true;
        private IOp? op = null;

        public Calculator(Display disp, Session sess)
        {
            this.disp = disp;
            this.sess = sess;
        }

        public bool IsRunning => run;
        public bool NeedsNum => op != null || steps.Count == 0;

        public async Task ProcessNumAsync(double x)
        {
            double r;
            int n = steps.Count + 1;

            if (steps.Count == 0)
            {
                r = x;
            }
            else if (op != null)
            {
                double last = steps[^1].Res;
                r = op.Apply(last, x);
            }
            else
            {
                throw new InvalidOperationException("операция не задана");
            }

            var step = new Step(n, r);
            steps.Add(step);

            await disp.ShowResultAsync(step);
            op = null;
        }

        public async Task ProcessOpAsync(IOp operation)
        {
            if (steps.Count == 0)
            {
                throw new InvalidOperationException("нельзя вводить операцию перед операндом");
            }
            op = operation;
            await Task.CompletedTask;
        }

        public async Task GoToStepAsync(int s)
        {
            if (s <= 0 || s > steps.Count)
            {
                throw new ArgumentOutOfRangeException($"номер шага {s} вне диапазона");
            }

            double r = steps[s - 1].Res;
            int n = steps.Count + 1;

            var step = new Step(n, r);
            steps.Add(step);

            await disp.ShowResultAsync(step);
            op = null;
        }

        public void Quit()
        {
            run = false;
        }

        public async Task SaveAsync()
        {
            await sess.SaveAsync(steps);
        }

        public double GetCurrentResult()
        {
            return steps.Count > 0 ? steps[^1].Res : 0;
        }
    }
}
