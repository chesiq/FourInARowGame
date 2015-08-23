using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FourInARowGame
{
    public partial class Field : Form
    {
        public const short ColumnsCount = 7;
        public const short RowsCount = 6;
        private const short CellSize = 75;

        private Cell[,] cells;
        private Graphics graphics;
        private Game game;
        private int playerTurn = 1;
        private short whichPlayer;
        private bool endGame = false;

        public Field()
        {
            InitializeComponent();
            game = new Game(RowsCount, ColumnsCount);

        }

        /// <summary>
        /// Restart button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restart_Click(object sender, EventArgs e)
        {
            game.Restart();
            ClearField();
        }

        /// <summary>
        /// Panel initialization event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            graphics = panel1.CreateGraphics();
            cells = new Cell[RowsCount, ColumnsCount];
            DrawGrid();
            UpdateTurnLabel();
            UpdateFields();
        }

        /// <summary>
        /// Field mouse down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (endGame) return;

            foreach (Cell obj in cells)
            {
                if (obj.IsClicked(e.X, e.Y) && game.MakeTurn(whichPlayer, obj.Column))
                {
                    UpdateFields();
                    if (game.CheckWinner())
                    {
                        MessageBox.Show(panel1, "Player" + whichPlayer + " wins!!!");
                        endGame = true;
                        return;
                    }
                    if (game.CheckDraw())
                    {
                        MessageBox.Show(panel1, "Draw!!!");
                        endGame = true;
                        return;
                    }
                    playerTurn++;
                    UpdateTurnLabel();                
                }
            }
        }

        /// <summary>
        /// Draws cells for game and save cells to list
        /// </summary>
        private void DrawGrid()
        {
            for (short x = 0; x < RowsCount; x++)
            {
                for (short y = 0; y < ColumnsCount; y++)
                {
                    Point loc = new Point(y * CellSize, x * CellSize);
                    graphics.DrawRectangle(Pens.Black, new Rectangle(loc, new Size(CellSize, CellSize)));
                    cells[x, y] = new Cell()
                    {
                        Location = loc,
                        Size = CellSize,
                        Column = (short)y
                    };
                }
            }
        }

        /// <summary>
        /// Updates label which player's turn is right now 
        /// </summary>
        private void UpdateTurnLabel()
        {
            String template = "Player{0}'s turn";
            whichPlayer = playerTurn % 2 == 0 ?  (short)2 : (short)1;
            player.Text = String.Format(template, whichPlayer);
            UpdatePlayerColor();
        }

        /// <summary>
        /// Draws circles depends on array from Game class
        /// </summary>
        private void UpdateFields()
        {
            int circleSize = Convert.ToInt32(CellSize * 0.75);

            for (short x = 0; x < RowsCount; x++)
                for (short y = 0; y < ColumnsCount; y++)
                {
                Point newLoc = cells[x,y].Location;
                newLoc.X += Convert.ToInt32(CellSize * 0.12);
                newLoc.Y += Convert.ToInt32(CellSize * 0.12);

                switch (game.Field[x, y])
                {
                    case 1:
                        graphics.FillEllipse(Brushes.Red, new Rectangle(newLoc, new Size(circleSize, circleSize)));
                        break;
                    case 2:
                        graphics.FillEllipse(Brushes.Yellow, new Rectangle(newLoc, new Size(circleSize, circleSize)));
                        break;
                    default:
                        break;
                }              
            }
        }

        /// <summary>
        /// Clears field 
        /// </summary>
        private void ClearField()
        {
            endGame = false;
            playerTurn = 1;
            UpdateTurnLabel();
            graphics.Clear(panel1.BackColor);
            DrawGrid();
        }

        /// <summary>
        /// Updates indicator current player's turn
        /// </summary>
        private void UpdatePlayerColor()
        {
            switch (whichPlayer)
            {
                case 1:
                    playerColor.BackColor = Color.Red;
                    break;
                case 2:
                    playerColor.BackColor = Color.Yellow;
                    break;
            }
        }
    }
}
