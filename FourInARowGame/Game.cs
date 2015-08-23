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

        /// <summary>
        /// Init field with zeros
        /// </summary>
        public void Restart()
        {
            field = new short[rowCount, columnCount];
            for (short row = 0; row < rowCount; row++)
                for (short col = 0; col < columnCount; col++)
                    field[row, col] = 0;
        }

        /// <summary>
        /// Method to make turn
        /// </summary>
        /// <param name="player">Player who made a turn</param>
        /// <param name="column">Which column to add</param>
        /// <returns>
        /// True if turn is successcull
        /// False otherwise
        /// </returns>
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

        /// <summary>
        /// Checks if it is a winner on the board
        /// </summary>
        /// <returns>
        /// True is winner exists
        /// </returns>
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

        /// <summary>
        /// Checks for draw
        /// </summary>
        /// <returns>
        /// True if its draw
        /// </returns>
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
