using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{


    public class ButtonClickedEventArgs : EventArgs
    {

        public ButtonView View;
        public ButtonClickedEventArgs(ButtonView view)
        {
            View = view;
        }
    }



    public class Button
    {
        public event EventHandler<ButtonClickedEventArgs> Clicked;

        public virtual void OnCliked(ButtonView view)
        {
            Clicked?.Invoke(this, new ButtonClickedEventArgs(view));
        }

    }

    public class MyButton : Button
    {
        public override void OnCliked(ButtonView view)
        {
            Console.WriteLine("AAAAAA");
            view.Color = Color.Red;
        }
    }
}
