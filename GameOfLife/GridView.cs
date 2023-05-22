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




        private IData<CellState> _data;
        private IView<Color> _view;

    }
}
