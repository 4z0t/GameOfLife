using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class ButtonView
    {

        public ButtonView(int x, int y, int w, int h, Color color, Button button)
        {
            _rect = new SFML.Graphics.IntRect(x, y, w, h);
            Color = color;
            _button = button;
        }

        public bool OnClicked(object? sender, MousePressedEventArgs args)
        {
            if (_rect.Contains(args.X, args.Y))
            {
                _button.OnCliked(this);
                if (sender is IView<Color> view)
                {
                    view.RequestRerender(this);
                }
                return true;
            }
            return false;
        }


        public void Render(object? sender, EventArgs args)
        {
            if (sender is not IView<Color> view)
                return;
            view.DrawRect(_rect.Top, _rect.Left, _rect.Width, _rect.Height, Color);
        }

        public Color Color { get; set; }


        private SFML.Graphics.IntRect _rect;

        private Button _button;
    }
}
