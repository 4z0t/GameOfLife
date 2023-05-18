using SFML;
using SFML.Graphics;
using SFML.Window;


namespace GameOfLife
{

    class Program
    {
        public static void Main(string[] args)
        {
            RenderWindow window = new(new VideoMode(200, 200), "SFML works!");
            CircleShape shape = new(100f);

            shape.FillColor = Color.Green;

            window.Resized += OnResize;
            window.Closed += OnClose;

            while (window.IsOpen)
            {

                window.DispatchEvents();


                window.Clear(Color.Black);
                window.Draw(shape);
                window.Display();

            }
        }


        static public void OnResize(object sender, SizeEventArgs args)
        {
            FloatRect r = new FloatRect(0, 0, args.Width, args.Height);
            RenderWindow window = sender as RenderWindow;
            if (window == null) return;
            window.SetView(new View(r));
        }

        static public void OnClose(object sender, EventArgs args)
        {
           
            RenderWindow window = sender as RenderWindow;
            if (window == null) return;
            window.Close();
        }
    }
}
