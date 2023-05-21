using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public interface IStrategy
    {
        void Action();
    }

    public class Button1 : IStrategy
    {
        public void Action()
        { }
    }

    public class Button2 : IStrategy
    {
        public void Action()
        { }
    }

    public class Button
    {
        public IStrategy ContextStrategy { get; set; }

        public Button(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Action();
        }
    }
}
