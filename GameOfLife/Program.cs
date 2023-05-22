using SFML;
using SFML.Graphics;
using SFML.Window;


namespace GameOfLife
{

    class Program
    {
        public static void Main(string[] args)
        {

            // Controller controller = new Controller();

            ViewSFML view = new ViewSFML();

            view.MouseClick += (o, e) =>
            {
                view.DrawRect(e.X, e.Y, 10, 10, Color.Green);
            };

            while (view.IsOpen)
            {
                view.Update();
               // view.Clear();
                //view.DrawRect(0,0, 10,10, Color.Green);
                view.Display();

            }
        }


    }
}

