using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class FixedData<T> : IModelGridData<T>
    {
        public FixedData(int size)
        {
            _grid = new T[size, size];
        }

        public FixedData(FixedData<T> other)
        {
            _grid = (T[,])other._grid.Clone();
        }

        public T this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= _grid.GetLength(0)) return default;
                if (y < 0 || y >= _grid.GetLength(1)) return default;
                return _grid[x, y];
            }
            set
            {
                if (x < 0 || x >= _grid.GetLength(0)) return;
                if (y < 0 || y >= _grid.GetLength(1)) return;
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

        public IModelGridData<T> Clone()
        {
            FixedData<T> clone = new(this);
            return clone;
        }

        private T[,] _grid;
    }
}

