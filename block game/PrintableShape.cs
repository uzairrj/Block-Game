using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace block_game
{
    class PrintableShape
    {
        protected int x; //position x
        protected int y; //position y
        protected ConsoleColor color;
        protected Board board;

        public PrintableShape(int x,int y,ConsoleColor color,Board board)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.board = board;
        }

        public void Erase()
        {
            // Both erase and paint behave the same
            // (the only difference is the colour we use to paint)
            Paint(true);
        }

        public void Draw()
        {
            Paint(false);
        }

        public void Paint(bool erase)
        {
            ConsoleColor tempColor = (erase) ? ConsoleColor.Black : color;
            Console.ForegroundColor = tempColor;
            Console.SetCursorPosition(x, y);
            board.Colours[x, y] = tempColor;
            Console.Write("█");
        }

        //polymorphism
        public virtual bool collide()
        {
            if(board.Colours[x, y] == ConsoleColor.Red)
            {
                return true;
            }
            return false;
        }
    }
}
