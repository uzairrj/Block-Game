using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace block_game
{
    class Board
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public ConsoleColor[,] Colours { get; set; }

        public Board(int SizeX, int SizeY)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            Colours = new ConsoleColor[SizeX, SizeY];
        }
    }
}
