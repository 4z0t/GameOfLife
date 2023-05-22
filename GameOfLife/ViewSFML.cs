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
            _window = new(new VideoMode(200, 200), "SFML works!");
            _window.Resized += ViewUtils.OnResize;
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

        private RenderWindow _window;

        public bool IsOpen => _window.IsOpen;
    }
}
