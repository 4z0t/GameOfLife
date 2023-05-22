using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GridView
    {
        public class GridViewEditState
        {

            public GridViewEditState()
            {

            }

            public virtual bool Action(GridView view, MouseMovedEventArgs args)
            {
                Console.WriteLine("no");
                return false;
            }
        }

        public class GridViewChangePositionState : GridViewEditState
        {

            public GridViewChangePositionState(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public override bool Action(GridView view, MouseMovedEventArgs args)
            {
                (double x1, double y1) = view.ScaleVector(args.X - _x, args.Y - _y);
                (double x2, double y2) = view.Position;
               view.Position = (x1 + x2, y1 + y2);


                //view.Position = view.TranslatePosition(_x - args.X, _y - args.Y);
                _x = args.X;
                _y = args.Y;
                //view.Position = view.ScaleVector(args.X - _x, args.Y - _y);
                Console.WriteLine(view.Position.ToString());
                return true;
            }

            private int _x;
            private int _y;
        }

        public class GridViewChangeCellState : GridViewEditState
        {
            public GridViewChangeCellState(CellState cell)
            {
                _cell = cell;
            }

            public override bool Action(GridView view, MouseMovedEventArgs args)
            {
                Console.WriteLine(_cell);
                return true;
            }

            private CellState _cell;
        }


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
                double x = i * expScale;
                for (int j = 0; j < gridHeight; j++)
                {
                    double y =  j * expScale ;
                    CellState cell = _data[(int)left + i, (int)top + j];
                    _view.DrawRect((int)x, (int)y, (int)expScale, (int)expScale, (cell == CellState.Alive) ? Color.White : Color.Blue);
                }
            }
        }


        public void SetAction(GridViewEditState state)
        {
            _state = state;
        }

        public void OnAction(MouseMovedEventArgs args)
        {
            if (_state.Action(this, args))
            {
                _view.Clear();
                this.Render();
            }
        }

        public (double, double) ScaleVector(int x, int y)
        {
            double expScale = Math.Pow(2, _scale);
            return (x / expScale, y / expScale);
        }

        public (double, double) TranslatePosition(int x, int y)
        {

            (int viewWidth, int viewHeight) = _view.Size;

            double expScale = Math.Pow(2, _scale);

            int centerX = viewWidth / 2;
            int centerY = viewHeight / 2;

            int dx = centerX - x;
            int dy = centerY - y;

            return (dx / expScale, dy / expScale);
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

        private GridViewEditState _state = new GridViewEditState();

    }
}
