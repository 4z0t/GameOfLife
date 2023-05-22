using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    using SFML.Graphics;
    using SFML.Window;
    using SFML.System;



    internal class ViewSFML : InputObservable, IView<Color>
    {

        public ViewSFML() : base()
        {
            _window = new RenderWindow(new VideoMode(200, 200), "SFML works!");
            _window.SetFramerateLimit(60);
            _window.Resized += ViewUtils.OnResize;
            _window.Closed += ViewUtils.OnClose;


            _window.MouseButtonPressed += (o, e) =>
            {
                this.OnMouseClick(new MouseClickEventArgs(e.X, e.Y));
            };

            _window.MouseWheelScrolled += (o, e) =>
            {
                this.OnMouseWheel(new MouseWheelEventArgs(e.X, e.Y, e.Delta));
            };
        }



        public void DrawRect(int x, int y, int w, int h, Color color)
        {
            _cachedPos.X = x; _cachedPos.Y = y;
            _cachedSize.X = w; _cachedSize.Y = h;
            _cachedRect.Position = _cachedPos;
            _cachedRect.Size = _cachedSize;
            _cachedRect.FillColor = ViewUtils.RemapColor(color);
            _window.Draw(_cachedRect);
        }

        public void Clear()
        {
            _window.Clear();
        }

        public void Display()
        {
            _window.Display();
        }

        public void Update()
        {
            _window.DispatchEvents();
        }
        public bool IsOpen => _window.IsOpen;

        public (int, int) Size
        {
            get
            {
                var size = _window.Size;
                return ((int)size.X, (int)size.Y);
            }
        }


        private RenderWindow _window;
        private Vector2f _cachedPos = new Vector2f();
        private Vector2f _cachedSize = new Vector2f();
        private RectangleShape _cachedRect = new RectangleShape();
    }
}
