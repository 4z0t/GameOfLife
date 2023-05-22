using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GridData : IData<CellState>
    {


        private readonly CellState[,] _cells = new CellState[100, 100];


        public CellState this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= _cells.GetLength(0)) return CellState.Empty;
                if (y < 0 || y >= _cells.GetLength(1)) return CellState.Empty;
                return _cells[x, y];
            }
            set
            {
                if (x < 0 || x >= _cells.GetLength(0)) return;
                if (y < 0 || y >= _cells.GetLength(1)) return;
                _cells[x, y] = value;
            }
        }

    }
}
