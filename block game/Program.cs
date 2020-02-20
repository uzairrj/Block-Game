using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace block_game
{
    class Program
    {
        static int WinLose(PrintableMovableShape player, PrintableMovableBarrier[] barrier,PrintableShape[] pickups, int count)
        {
            foreach(var item in barrier)
            {
                if (item.collide() || player.collide())
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You Loose!\n");
                    return -1;
                }
            }

            if (player.collide())
            {
                count++;
            }

            for(int i=0;i<3;i++)
            {
                if (pickups[i] != null && pickups[i].collide())
                {
                    pickups[i] = null;
                    count++;
                    if(count >= 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("You Won!\n");
                        return -1;
                    }
                }
            }

            return count;
        }
        static void Main(string[] args)
        {
            #region Constants
            const int width = 70; //width constant
            const int height = 30; //height constant
            const ConsoleColor powerupColor = ConsoleColor.Yellow; //powerup color
            const ConsoleColor barierColor = ConsoleColor.Green; //barier color
            const ConsoleColor playerColor = ConsoleColor.Red; //player color
            #endregion

            #region Console Settings
            //setting console properties
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.CursorVisible = false;
            #endregion

            #region Variables
            Random rand = new Random(87965);
            Board board = new Board(width,height);
            PrintableShape[] powerup = new PrintableShape[3];
            PrintableMovableShape player = new PrintableMovableShape(width / 2, height / 2, playerColor, board);
            PrintableMovableBarrier[] barriers = new PrintableMovableBarrier[4];
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            int powerPickups = 0;
            #endregion

            //displaying the powerups
            for (int i = 0; i < 3; i++)
            {
                powerup[i] = new PrintableShape(rand.Next(width), rand.Next(height), powerupColor, board);
                powerup[i].Draw();
            }

            //displaying the player
            player.Draw();

            //displaying barrier
            barriers[0] = new PrintableMovableBarrier(width-1, 5, barierColor, board, orintation.left);
            barriers[1] = new PrintableMovableBarrier(0, 18, barierColor, board, orintation.right);
            barriers[2] = new PrintableMovableBarrier(22, height-1, barierColor, board, orintation.top);
            barriers[3] = new PrintableMovableBarrier(48, 0, barierColor, board, orintation.down);


            while (true)
            {
                dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalMilliseconds > 50)
                {
                    foreach (var item in barriers)
                    {
                        item.Move();
                       
                    }

                    dt1 = DateTime.Now;
                }

                // Check for any key presses
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo k = Console.ReadKey(true);
                    string feedback = string.Empty;

                    switch (k.Key)
                    {
                        case ConsoleKey.DownArrow:
                            player.MoveDown();
                            break;
                        case ConsoleKey.LeftArrow:
                            player.MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            player.MoveRight();
                            break;
                        case ConsoleKey.UpArrow:
                            player.MoveUp();
                            break;
                    }
                }

                powerPickups = WinLose(player, barriers, powerup, powerPickups);

                if(powerPickups == -1)
                {
                    break;
                }
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
