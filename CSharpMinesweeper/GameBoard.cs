using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpMinesweeper
{
    
    class GameBoard
    {
        private int[,] adjacentCells = { { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 } };
        private int bombCount = 0;

        public event CellPlayed Move; // Ferry event result to the form to avoid a transitive depencency.

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int RemainingCount { get; private set; }

        public Cell[,] Cells { get; private set; }

        public GameBoard(int height, int width, int bombChance)
        {
            Height = height;
            Width = width;

            Random rng = new Random(); // Setting the seed for random. Change this after testing...

            Cells = new Cell[height, width];

            Cell.CellType type;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (rng.Next(0, bombChance) == 0)
                    {
                        type = Cell.CellType.Bomb;
                        bombCount++;
                    }
                    else
                        type = Cell.CellType.Empty;
                    Cell c = new Cell(type, i, j);
                    Cells[i, j] = c;
                    c.CellPlayed += C_OnCellPlayed;
                }
            }
            RemainingCount = Height * Width - bombCount;
           
            
            Action<Cell, int, int> countAdjacentBombs = (Cell currentCell, int x, int y) =>
            {
                // Adjacent cell is a bomb and the current cell can take a number, set the cell to number
                // and increment the adjacent bomb count.
                if (currentCell.Type != Cell.CellType.Bomb && Cells[x, y].Type == Cell.CellType.Bomb)
                {
                    currentCell.IncrementBombCount();
                    currentCell.SetType(Cell.CellType.Numbered);
                }
            };

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    CheckAdjacent(countAdjacentBombs, i, j);
                }
            }
        }

        /// <summary>
        /// Checks all of the cells adjacent to the cell specified by the coordinates i, j.
        /// </summary>
        /// <param name="function">An action delegate that takes the current cell and coordinates of the adjacent cell</param>
        /// <param name="i">row coordinate of the current cell</param>
        /// <param name="j">column coordinate of the current cell</param>
        public void CheckAdjacent(Action<Cell, int, int> function, int i, int j)
        {
            for (int dir = 0; dir < 8; dir++)
            {
                if (i + adjacentCells[dir, 0] < 0 || i + adjacentCells[dir, 0] > Height - 1
                    || j + adjacentCells[dir, 1] < 0 || j + adjacentCells[dir, 1] > Width - 1)
                {
                    continue;
                }
                else
                {
                    int x = i + adjacentCells[dir, 0];
                    int y = j + adjacentCells[dir, 1];

                    function.Invoke(Cells[i, j], x, y);
                }
            }
        }

        // The cell's button has been clicked. It raises this event.
        // source: Cell, e: Move Result
        private void C_OnCellPlayed(object source, CellPlayedArgs e)
        {
            Cell c = (Cell)source;
            GameTypes.MoveResult result = e.GetResult();

            if (c.Type == Cell.CellType.Empty)
            {
                RemainingCount--;

                /// If a played cell is empty, recursively check the specified adjacent cell. Plays all empty sets of cells.
                Action<Cell, int, int> ClearEmptyCellsAction = (Cell currentCell, int x, int y) =>
                {
                    void inner(Cell cCell, int t, int s)
                    {
                        if (cCell.Type == Cell.CellType.Empty && Cells[t, s].IsPlayed == false)
                        {
                            Cells[t, s].PlayCell(true);
                            RemainingCount--;
                            Console.WriteLine("Checking Adjacent: {0}, {1}", t, s);
                            CheckAdjacent(inner, t, s);
                        }
                    }
                    inner(currentCell, x, y);
                };

                CheckAdjacent(ClearEmptyCellsAction, c.M, c.N);
            }
            else
            {
                if (result == GameTypes.MoveResult.Continue)
                {
                    RemainingCount--;
                    if (RemainingCount == 0)
                        result = GameTypes.MoveResult.Win;
                }
            }

            // Remove the event handler on all of the buttons to disable them while leaving the text.
            if (result == GameTypes.MoveResult.Loss)
            {
                RevealBombs();
                foreach (Cell ce in Cells)
                    ce.DisableButton();
            }
                

            Move(this, new CellPlayedArgs(result)); // Send the move result to the form.
        }

        public void RevealBombs()
        {
            foreach (Cell c in Cells)
                if (c.Type == Cell.CellType.Bomb)
                    c.PlayCell(false);
        }

    }
}
