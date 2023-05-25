using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class LoopedData<T> : IModelGridData<T>
    {
        public LoopedData(int size)
        {
            _grid = new T[size, size];
        }

        public T this[int x, int y]
        {
            get
            {
                x = x % _grid.GetLength(0);
                y = y % _grid.GetLength(1);
                return _grid[x, y];
            }
            set
            {
                x = x % _grid.GetLength(0);
                y = y % _grid.GetLength(1);
                _grid[x, y] = value;
            }
        }

        public (int, int) GetStartIndex()
        {
            return (0, 0);
        }

        public (bool, int, int) Next(int x, int y)
        {
            if (x + 1 != _grid.GetLength(0)) return (true, x + 1, y);

            if (y + 1 != _grid.GetLength(1)) return (true, 0, y + 1);

            return (false, 0, 0);
        }

        private T[,] _grid;
    }
}
