using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace block_game
{
    class PrintableMovableShape : PrintableShape
    {
        public PrintableMovableShape(int x, int y, ConsoleColor color, Board board) : base(x, y, color, board)
        {

        }

        public void MoveUp()
        {
            if (CanMakeMove(x, y - 1) == string.Empty)
            {
                Erase();
                y--;
                Draw();
            }
        }
        public void MoveDown()
        {
            if (CanMakeMove(x, y + 1) == string.Empty)
            {
                Erase();
                y++;
                Draw();
            }
        }
        public void MoveLeft()
        {
            if (CanMakeMove(x - 1, y) == string.Empty)
            {
                Erase();
                x--;
                Draw();
            }
        }
        public void MoveRight()
        {
            if (CanMakeMove(x + 1, y) == string.Empty)
            {
                Erase();
                x++;
                Draw();
            }
        }

        public string CanMakeMove(int proposedX,int proposedY)
        {
            if(proposedX <=0 || proposedY <=0 || proposedX >= board.SizeX || proposedY >= board.SizeY)
            {
                return "HitBorder";
            }

            return String.Empty;
        }

        public override bool collide()
        {
            if (board.Colours[x, y] == ConsoleColor.Green)
            {
                return true;
            }
            return false;
        }
    }
}
