using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{


    public enum MouseButton
    {
        Left,
        Middle,
        Right,
    }


    public class MouseMovedEventArgs : EventArgs
    {

        public int X, Y;

        public MouseMovedEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class MousePressedEventArgs : MouseMovedEventArgs
    {
        public MouseButton Button;
        public MousePressedEventArgs(int x, int y, MouseButton button) : base(x, y)
        {
            Button = button;
        }
    }


    public class MouseReleasedEventArgs : MousePressedEventArgs
    {
        public MouseReleasedEventArgs(int x, int y, MouseButton button) : base(x, y, button)
        {

        }
    }





    public class MouseWheelEventArgs : MouseMovedEventArgs
    {

        public double Delta;

        public MouseWheelEventArgs(int x, int y, double delta) : base(x, y)
        {
            Delta = delta;
        }
    }


    internal class InputObservable
    {
        public event EventHandler<MousePressedEventArgs> MousePress;
        public event EventHandler<MouseReleasedEventArgs> MouseRelease;
        public event EventHandler<MouseMovedEventArgs> MouseMove;
        public event EventHandler<MouseWheelEventArgs> MouseWheel;

        public InputObservable()
        {

        }

        protected void OnMousePressed(MousePressedEventArgs args)
        {
            MousePress?.Invoke(this, args);
        }

        protected void OnMouseWheel(MouseWheelEventArgs args)
        {
            MouseWheel?.Invoke(this, args);
        }

        protected void OnMouseMoved(MouseMovedEventArgs args)
        {
            MouseMove?.Invoke(this, args);
        }

        protected void OnMouseReleased(MouseReleasedEventArgs args)
        {
            MouseRelease?.Invoke(this, args);
        }
    }
}
