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
            get => CellState.Alive;
            set
            {

            }
        }

    }
}
