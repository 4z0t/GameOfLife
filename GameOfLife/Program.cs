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


            while (view.IsOpen)
            {
                view.Update();
                view.Clear();
                view.DrawRect(0,0, 10,10, Color.Green);
                view.Display();

            }
        }
       

        static public void OnClose(object sender, EventArgs args)
        {

            RenderWindow window = sender as RenderWindow;
            if (window == null) return;
            window.Close();
        }

    }
}

