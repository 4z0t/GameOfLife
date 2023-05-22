using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public class MouseClickEventArgs : EventArgs
    {

        public int X, Y;

        public MouseClickEventArgs(int x, int y)
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

        protected void OnMouseClick(MouseClickEventArgs args)
        {
            MouseClick?.Invoke(this, args);
        }
    }
}
