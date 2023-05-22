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

    public class MouseWheelEventArgs : MouseClickEventArgs
    {

        public double Delta;

        public MouseWheelEventArgs(int x, int y, double delta) : base(x, y)
        {
            Delta = delta;
        }
    }


    internal class InputObservable
    {
        public event EventHandler<MouseClickEventArgs> MouseClick;
        public event EventHandler<MouseWheelEventArgs> MouseWheel;

        public InputObservable()
        {

        }

        protected void OnMouseClick(MouseClickEventArgs args)
        {
            MouseClick?.Invoke(this, args);
        }

        protected void OnMouseWheel(MouseWheelEventArgs args)
        {
            MouseWheel?.Invoke(this, args);
        }
    }
}
