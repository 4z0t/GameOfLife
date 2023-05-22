using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    using SFMLColor = SFML.Graphics.Color;
    internal class ViewUtils
    {
        static public void OnResize(object? sender, SizeEventArgs args)
        {
            if (sender is not RenderWindow window)
                return;

            window.SetView(new View(new FloatRect(0, 0, args.Width, args.Height)));
        }

        public static SFMLColor RemapColor(Color color) => color switch
        {
            Color.Red => SFMLColor.Red,
            Color.Green => SFMLColor.Green,
            Color.Blue => SFMLColor.Blue,
            Color.White => SFMLColor.White,
            Color.Black => SFMLColor.Black,
            _ => SFMLColor.Black
        };
    }
}
