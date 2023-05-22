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
                MouseButton button = e.Button switch
                {
                    Mouse.Button.Left => MouseButton.Left,
                    Mouse.Button.Right => MouseButton.Right,
                    Mouse.Button.Middle => MouseButton.Middle,
                    _ => MouseButton.Left,

                };
                this.OnMousePressed(new MousePressedEventArgs(e.X, e.Y, button));
            };

            _window.MouseButtonReleased += (o, e) =>
            {
                MouseButton button = e.Button switch
                {
                    Mouse.Button.Left => MouseButton.Left,
                    Mouse.Button.Right => MouseButton.Right,
                    Mouse.Button.Middle => MouseButton.Middle,
                    _ => MouseButton.Left,

                };
                this.OnMouseReleased(new MouseReleasedEventArgs(e.X, e.Y, button));
            };

            _window.MouseMoved += (o, e) =>
            {
                this.OnMouseMoved(new MouseMovedEventArgs(e.X, e.Y));
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
            _needDisplay = true;
        }

        public void Clear()
        {
            _window.Clear();
        }

        public void Display()
        {
            if (_needDisplay)
            {
                _window.Display();
                _needDisplay = false;
            }
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
        private bool _needDisplay = false;
    }
}
