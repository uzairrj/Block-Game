using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace block_game
{
    public enum orintation { left = 0, right, top, down };
    class PrintableMovableBarrier:PrintableMovableShape
    {
        private orintation orientation;

        public PrintableMovableBarrier(int x, int y, ConsoleColor color, Board board, orintation orientation) : base(x, y, color, board)
        {
            this.orientation = orientation;
        }

        public void Move()
        {
            if(orientation == orintation.left)
            {
                if(CanMakeMove(x-1,y) == string.Empty)
                {
                    MoveLeft();
                }
                else
                {
                    orientation = orintation.right;
                }
            }
            else if(orientation == orintation.right)
            {
                if (CanMakeMove(x + 1, y) == string.Empty)
                {
                    MoveRight();
                }
                else
                {
                    orientation = orintation.left;
                }
            }
            else if (orientation == orintation.top)
            {
                if (CanMakeMove(x, y-1) == string.Empty)
                {
                    MoveUp();
                }
                else
                {
                    orientation = orintation.down;
                }
            }
            else if (orientation == orintation.down)
            {
                if (CanMakeMove(x, y + 1) == string.Empty)
                {
                    MoveDown();
                }
                else
                {
                    orientation = orintation.top;
                }
            }
        }

        public override bool collide()
        {
            if (board.Colours[x, y] == ConsoleColor.Red)
            {
                return true;
            }
            return false;
        }

    }
}
