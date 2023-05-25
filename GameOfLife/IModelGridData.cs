using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal interface IModelGridData<T> : IData<T>
    {
        public (int, int) GetStartIndex();
        public (bool, int, int) Next(int x, int y);
    }
}
