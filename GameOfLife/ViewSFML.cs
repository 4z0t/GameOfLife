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
            _window = new RenderWindow(new VideoMode(200, 200), "SFML works!" );
            _window.SetFramerateLimit(60);
            _window.Resized += ViewUtils.OnResize;
            _window.Closed += ViewUtils.OnClose;

            _window.MouseButtonPressed += (o, e) =>
            {
                this.OnMouseClick(new MouseClickEventArgs(e.X, e.Y));
            };
        }



        public void DrawRect(int x, int y, int w, int h, Color color)
        {
            RectangleShape rect = new();
            rect.Position = new Vector2f(x, y);
            rect.Size = new Vector2f(w, h);
            rect.FillColor = ViewUtils.RemapColor(color);
            _window.Draw(rect);
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



        private RenderWindow _window;
    }
}
