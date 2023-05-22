using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public class MouseClickEventArgs : EventArgs
    {

        public uint X, Y;

        public MouseClickEventArgs(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }


    internal class InputObservable
    {
        public event EventHandler<MouseClickEventArgs> MouseClick;

        public InputObservable()
        {

        }
    }
}
