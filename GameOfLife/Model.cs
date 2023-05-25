using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Model : IData<CellState>
    {
        private IModelGridData<int> _grid;
        private int gridSize;
        private int AliveCounter;

        public CellState this[int x, int y]
        {
            get
            {
                var v = _grid[x, y];
                return v switch
                {
                    0 => CellState.Empty,
                    1 => CellState.Alive,
                    _ => CellState.Empty
                };

            }
            set
            {
                _grid[x, y] = value switch
                {
                    CellState.Alive => 1,
                    _ => 0
                };
            }
        }
        public Model(IModelGridData<int> data)
        {
            _grid = data;
            Reset(gridSize);
        }


        private void ChangeCounter(int newCount)
        {
            if (newCount == 1 && AliveCounter + 1 <= gridSize * gridSize)
            {
                AliveCounter += 1;
            }
            else if (newCount == -1 && AliveCounter - 1 >= 0)
            {
                AliveCounter -= 1;
            }
        }

        private void Reset(int size) // установка всех клеток пустыми
        {

        }


        public int Update()
        {

            int count = 0;
            IModelGridData<int> oldGrid = _grid.Clone();

            foreach ((int i, int j, int val) in new GridIterator<int>(oldGrid))
            {
                count = oldGrid[i - 1, j + 1] + oldGrid[i, j + 1] + oldGrid[i + 1, j + 1]
                   + oldGrid[i - 1, j] + oldGrid[i + 1, j] +
                   +oldGrid[i - 1, j - 1] + oldGrid[i, j - 1] + oldGrid[i + 1, j - 1];
                if (count == 3 && oldGrid[i, j] == 0)
                {
                    _grid[i, j] = 1;
                }
                else if ((count == 2 || count == 3) && oldGrid[i, j] == 1)
                {
                }
                else
                {
                    _grid[i, j] = 0;
                }
            }
            if (AliveCounter == 0)
            {
                return 1;
            }
            return 0;
        }
    }
}

