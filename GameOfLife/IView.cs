using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal interface IView<TColor>
    {
        public (int, int) Size { get; }
        public void DrawRect(int x, int y, int w, int h, TColor color);
        public void Clear();
        public void Display();
        public void Update();

        public bool IsOpen { get; }
    }
}
