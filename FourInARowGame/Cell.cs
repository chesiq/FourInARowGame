using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FourInARowGame
{
    class Cell
    {
        public Point Location { get; set; }
        public int Size { get; set; }
        public short Column { get; set; }
        public Rectangle Rect {
            get { return new Rectangle(Location, new Size(Size, Size)); }
        }

        /// <summary>
        /// Checks if we clicked on cell rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsClicked(int x, int y)
        {
            return Rect.Contains(x, y);
        }
    }
}
