using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GridData : IData<CellState>

    {
        public CellState this[int x, int y]
        {
            get
            {
                return ((x + y) % 2 == 1) ? CellState.Alive : CellState.Empty;
            }
            set
            {

            }
        }

    }
}
