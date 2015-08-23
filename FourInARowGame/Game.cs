using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourInARowGame
{
    class Game
    {
        private const short Threshold = 4 - 1;

        private short[,] field;
        private short rowCount;
        private short columnCount;

        public short[,] Field
        {
            get { return field; }
        }

        public Game(short rowCount, short columnCount)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            Restart();
        }

        public void Restart()
        {
            field = new short[,] { 
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };
        }

        public bool MakeTurn(short player, short column)
        {
            for (short row = (short)(rowCount - 1); row >= 0; row--)
                if (field[row, column] == 0)
                {
                    field[row, column] = player;
                    return true;
                }
            return false;
        }

        public bool CheckWinner()
        {
            //Check verticals
            for (short row = 0; row < rowCount - Threshold; row++)
                for (short col = 0; col < columnCount; col++)
                    if ((field[row, col] != 0) &&
                       (field[row, col] == field[row + 1, col]) &&
                       (field[row, col] == field[row + 2, col]) &&
                       (field[row, col] == field[row + 3, col]))
                        return true;

            //Check horizontals
            for (short row = 0; row < rowCount; row++)
                for (short col = 0; col < columnCount - Threshold; col++)
                    if ((field[row, col] != 0) &&
                       (field[row, col] == field[row, col + 1]) &&
                       (field[row, col] == field[row, col + 2]) &&
                       (field[row, col] == field[row, col + 3]))
                        return true;

            //Check diagonals
            for (short col = 0; col < columnCount - Threshold; col++)
            {
                //Right-down
                for (short row = 0; row < rowCount - Threshold; row++)
                    if ((field[row, col] != 0) &&
                       (field[row, col] == field[row + 1, col + 1]) &&
                       (field[row, col] == field[row + 2, col + 2]) &&
                       (field[row, col] == field[row + 3, col + 3]))
                        return true;

                //Right-up
                for (short row = (short)(rowCount - Threshold); row < rowCount; row++)
                    if ((field[row, col] != 0) &&
                       (field[row, col] == field[row - 1, col + 1]) &&
                       (field[row, col] == field[row - 2, col + 2]) &&
                       (field[row, col] == field[row - 3, col + 3]))
                        return true;
            }
            return false;
        }

        public bool CheckDraw()
        {
            for (short row = 0; row < rowCount; row++)
                for (short col = 0; col < columnCount; col++)
                    if (field[row, col] == 0)
                        return false;
            return true;
        }
    }
}
