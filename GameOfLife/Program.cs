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
            grid.Scale = 4;

            Button button = new Button();
            ButtonView buttonView = new ButtonView(30, 30, 200, 100, Color.Green, button);


            button.Clicked += (o, e) =>
            {
                grid.Position = (0, 0);
            };

            view.MousePress += (o, e) =>
            {
                if (buttonView.OnClicked(o, e))
                {
                    return;
                }
                if (e.Button == MouseButton.Middle)
                {
                    grid.SetAction(new GridView.GridViewChangePositionState(e.X, e.Y), e);
                }
                else
                {
                    grid.SetAction(new GridView.GridViewChangeCellState(e.Button switch
                    {
                        MouseButton.Left => CellState.Alive,
                        MouseButton.Right => CellState.Empty,
                        _ => CellState.Empty,
                    }), e);
                }
                view.RequestRerender(grid);
            };

            view.MouseRelease += (o, e) =>
            {
                grid.SetAction(new GridView.GridViewEditState(), e);
            };

            view.MouseMove += (o, e) =>
            {
                grid.OnAction(e);
            };

            view.MouseWheel += (o, e) =>
            {
                grid.Scale += e.Delta;
                view.RequestRerender(grid);
            };

            view.ViewChanged += grid.Render;
            view.ViewChanged += buttonView.Render;




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

