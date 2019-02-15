using System;
using System.Windows.Forms;
using System.Drawing;

namespace CSharpMinesweeper
{
    class CellPlayedArgs : EventArgs
    {
        private GameTypes.MoveResult result;
        public CellPlayedArgs(GameTypes.MoveResult moveResult)
        {
            result = moveResult;
        }
        public GameTypes.MoveResult GetResult()
        {
            return result;
        }
    }

    delegate void CellPlayed(object source, CellPlayedArgs e);

    class Cell
    {
        public enum CellType { Bomb, Empty, Numbered }


        public CellType Type { get; private set; }
        public bool IsPlayed { get; private set; }
        public bool IsMarked { get; private set; }
        public int AdjacentBombCount { get; private set; } // Set bombs with an rng first, then go back and set the adjacent bomb count and cell type.
        public int M { get; private set; }
        public int N { get; private set; }
        public Button Button { get; private set; }

        public event CellPlayed CellPlayed;

        public Cell(CellType type, int m, int n)
        {
            IsPlayed = false;
            IsMarked = false;
            M = m;
            N = n;
            Type = type;
            AdjacentBombCount = 0;
            Button = new Button() { BackgroundImageLayout = ImageLayout.Stretch };
            Button.MouseDown += Button_MouseDown; ;
        }

        public void SetType(CellType newType) { Type = newType; }
        public void IncrementBombCount() { AdjacentBombCount++; }

        public void SetDisplay()
        {
            if (IsPlayed)
            {
                if (Type == CellType.Empty) { }
                else if (Type == CellType.Bomb)
                    Button.BackgroundImage = new Bitmap("mine.jpg");
                else
                {
                    Button.Text = AdjacentBombCount.ToString();
                }
            }
            else if (IsMarked)
                Button.BackgroundImage = new Bitmap("flag.png");

        }

        public void DisableButton()
        {
            Button.MouseDown -= Button_MouseDown;
        }

        // Activate the cell and trigger an event with the result.
        // Deactivates the button and updates the text for the button.
        public GameTypes.MoveResult PlayCell(bool trigger)
        {
            IsPlayed = true;
            GameTypes.MoveResult result;
            Update();

            if (Type == CellType.Bomb)
                result = GameTypes.MoveResult.Loss;
            else
                result = GameTypes.MoveResult.Continue;

            if (trigger)
                CellPlayed(this, new CellPlayedArgs(result)); // Clicking a cell's button or calling this method from GameBoard.cs will fire the event for the form.

            return result;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (! IsPlayed)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Button.BackColor = Color.White;
                        PlayCell(true);
                        break;

                    case MouseButtons.Right:
                        ToggleMarked();
                        Update();
                        break;
                }
            }
        }

        public void Update()
        {

            SetDisplay();

            if (IsPlayed)
            {
                if (Type == Cell.CellType.Bomb)
                    Button.BackColor = Color.Firebrick;
                else
                    Button.BackColor = Color.White;
            }
        }

        public void ToggleMarked()
        {
            IsMarked = !IsMarked;
        }
    }
}
