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
            GridData gridData = new GridData();
            GridView grid = new GridView(gridData, view);

            view.MousePress += (o, e) =>
            {
                if (e.Button == MouseButton.Middle)
                {
                    grid.SetAction(new GridView.GridViewChangePositionState(e.X, e.Y));
                    return;
                }
                grid.SetAction(new GridView.GridViewChangeCellState(e.Button switch
                {
                    MouseButton.Left => CellState.Alive,
                    MouseButton.Right => CellState.Empty,
                    _ => CellState.Empty,
                }));
            };

            view.MouseRelease += (o, e) =>
            {
                grid.SetAction(new GridView.GridViewEditState());
            };

            view.MouseMove += (o, e) =>
            {
                grid.OnAction(e);
                view.Display();
            };

            view.MouseWheel += (o, e) =>
            {
                grid.Scale += e.Delta;
                view.Clear();
                grid.Render();
                view.Display();
            };

            while (view.IsOpen)
            {
                view.Update();

                // view.Clear();
                //view.DrawRect(0,0, 10,10, Color.Green);
                //view.Display();

            }
        }


    }
}

