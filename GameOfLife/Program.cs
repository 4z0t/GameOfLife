using SFML;
using SFML.Graphics;
using SFML.Window;


namespace GameOfLife
{

    class Program
    {
        public static void Main(string[] args)
        {


            SFML.System.Clock clock = new SFML.System.Clock();
            LoopedData<int> gridData = new(100);

            Model model = new Model(gridData);
            ViewSFML view = new ViewSFML();
            GridView grid = new GridView(model, view);
            grid.Scale = 4;

            Button button = new Button();
            Button updateButton = new Button();
            Button resetButton = new Button();
            Button repeatButton = new Button();
            ButtonView buttonView = new ButtonView(30, 30, 200, 100, Color.Green, button);
            ButtonView updateButtonView = new ButtonView(500, 30, 200, 100, Color.Red, updateButton);
            ButtonView resetButtonView = new ButtonView(970, 30, 200, 100, Color.White, resetButton);
            ButtonView repeatButtonView = new ButtonView(1440, 30, 200, 100, Color.Blue, repeatButton);
            bool updateFlag = false;

            button.Clicked += (o, e) =>
            {

                grid.Position = (0, 0);

            };


            updateButton.Clicked += (o, e) =>
            {
                model.Update();
            };

            resetButton.Clicked += (o, e) =>
            {
                Console.WriteLine("Reset");
                

            };

            repeatButton.Clicked += (o, e) =>

            {
                updateFlag = !updateFlag;

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
                if (resetButtonView.OnClicked(o, e))
                {
                    return;
                }
                if (repeatButtonView.OnClicked(o, e))
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
            view.ViewChanged += resetButtonView.Render;
            view.ViewChanged += repeatButtonView.Render;




            while (view.IsOpen)
            {
                view.Update();
                if (updateFlag)
                {
                    if (clock.ElapsedTime >= SFML.System.Time.FromMilliseconds(300))
                    {
                        clock.Restart();
                        model.Update();
                        view.RequestRerender(null);
                    }
                }
                // view.Clear();
                //view.DrawRect(0,0, 10,10, Color.Green);
                //view.Display();

            }
        }


    }
}

