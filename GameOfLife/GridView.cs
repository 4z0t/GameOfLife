using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GridView
    {



        public GridView(IData<CellState> data, IView<Color> view)
        {
            _data = data;
            _view = view;
        }


        public void Render()
        {
            (int viewWidth, int viewHeight) = _view.Size;

            double expScale = Math.Pow(2, _scale);

            double width = viewWidth / expScale;
            double height = viewHeight / expScale;

            double left = _x - width / 2;
            double right = _x + width / 2;

            double top = _y - height / 2;
            double bottom = _y + height / 2;

            int gridWidth = (int)Math.Ceiling(width);
            int gridHeight = (int)Math.Ceiling(height);

            for (int i = 0; i < gridWidth; i++)
            {
                double x = (left + i) * expScale + viewWidth / 2;
                for (int j = 0; j < gridHeight; j++)
                {
                    double y = (top + j) * expScale + viewHeight / 2;
                    _view.DrawRect((int)x, (int)y, (int)expScale, (int)expScale, ((i + j) % 2 == 1) ? Color.White : Color.Blue);
                }
            }
        }


        public double Scale
        {
            get { return _scale; }
            set { _scale = Math.Max(value, 0); }
        }

        public (double, double) Position
        {
            get { return (_x, _y); }
            set { (_x, _y) = value; }
        }

        private double _scale = 0;
        private double _x = 0;
        private double _y = 0;


        private IData<CellState> _data;
        private IView<Color> _view;

    }
}
