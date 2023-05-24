using SFML;
using SFML.Graphics;
using SFML.Window;


namespace GameOfLife
{

    class Program
    {
        public static void Main(string[] args)
        {



            Data gridData = new Data();
            ViewSFML view = new ViewSFML();
            GridView grid = new GridView(gridData, view);
            grid.Scale = 4;

            Button button = new Button();
            Button updateButton = new Button();
            ButtonView buttonView = new ButtonView(30, 30, 200, 100, Color.Green, button);
            ButtonView updateButtonView = new ButtonView(500, 30, 200, 100, Color.Red, updateButton);


            button.Clicked += (o, e) =>
            {
                grid.Position = (0, 0);
            };

            updateButton.Clicked += (o, e) =>
            {
                gridData.Update();
            };

            view.MousePress += (o, e) =>
            {
                if (updateButtonView.OnClicked(o, e))
                {
                    return;
                }
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
                grid.SetAction(GridView.DefaultState, e);
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
            view.ViewChanged += updateButtonView.Render;




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

