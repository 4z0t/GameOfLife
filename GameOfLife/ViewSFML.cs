using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    using SFML.Graphics;
    using SFML.Window;

    internal class ViewSFML : IView<Color>
    {
        public ViewSFML()
        {
            _window = new(new VideoMode(200, 200), "SFML works!");
            
        }

        public void DrawRect(int x, int y, int w, int h, Color color)
        {
            throw new NotImplementedException();
        }


        private RenderWindow _window;
    }
}
