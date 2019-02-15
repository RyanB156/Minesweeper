using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CSharpMinesweeper
{
    public partial class Form1 : Form
    {

        int height;
        int width;
        int bombChancePercentage;
        int bombChance;

        int boxSize;

        string saveFilePath;

        GameBoard gameBoard;

        public Form1()
        {
            saveFilePath = "SaveData.bin";

            if (File.Exists(saveFilePath))
            {
                BinaryReader br = new BinaryReader(File.Open(saveFilePath, FileMode.Open));
                height = br.ReadInt32();
                width = br.ReadInt32();
                bombChancePercentage = br.ReadInt32();
                br.Close();
            }
            else
            {
                height = 20;
                width = 20;
                bombChancePercentage = 20;
            }

            InitializeComponent();

            heightBox.Text = $"{height}";
            widthBox.Text = $"{width}";
            bombChanceBox.Text = $"{bombChancePercentage}";

            bombChance = (bombChancePercentage != 0) ? (100 / bombChancePercentage) : 1;

            boxSize = 35;

            ClientSize = new Size(boxSize * width, boxSize * height);

            gameBoard = new GameBoard(height, width, bombChance);
            gameBoard.Move += GameBoard_Move;

            this.Text = $"{gameBoard.RemainingCount}";
            this.KeyPreview = true;
            this.KeyUp += Form1_KeyUp;

            optionMenu.Visible = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Cell c = gameBoard.Cells[i, j];
                    c.Button.SetBounds(boxSize * j, boxSize * i, boxSize, boxSize);
                    Controls.Add(c.Button);
                }
            }
        }

        private void GameBoard_Move(object source, CellPlayedArgs e)
        {
            if (e.GetResult() != GameTypes.MoveResult.Continue)
            {
                if (e.GetResult() == GameTypes.MoveResult.Win)
                    Text = "You Win!";
                else if (e.GetResult() == GameTypes.MoveResult.Loss)
                    Text = "You Lose :(";
            }       
                   
        }

        private void ToggleMenu()
        {
            optionMenu.Visible = !optionMenu.Visible;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                    Application.Restart();
                    break;
                case Keys.Escape:
                    ToggleMenu();
                    break;
            }
        }

        private void WriteData()
        {
            BinaryWriter bw = new BinaryWriter(File.Open(saveFilePath, FileMode.Create));
            bw.Write(height);
            bw.Write(width);
            bw.Write(bombChance);
            bw.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            WriteData();
            Application.Restart();
        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(heightBox.Text, out height);
            Console.WriteLine("Height Changed!");
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(widthBox.Text, out width);
        }

        private void bombChanceBox_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(bombChanceBox.Text, out bombChance);
        }
    }
}
