using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Game;
using Gomoku.Players;

namespace Gomoku
{
    class ConsoleIO
    {
        public void DisplayTitle()
        {
            System.Console.WriteLine(
                "Welcome to Gomoku!\n" +
                "==================");
        }
        public void DisplayPlayerMenu(int playerNum)
        {
            System.Console.Write($"\nPlayer {playerNum} is:\n1. Human\n2. Random Player\nSelect [1-2]: ");
        }
        public void Display(string message)
        {
            System.Console.Write(message);
        }

        public void PrintBoard(GomokuEngine gomokuEngine)
        {
            Console.WriteLine("");
            for (int r = 0; r < GomokuEngine.WIDTH + 1; r++)
            {
                for (int c = 0; c < GomokuEngine.WIDTH + 1; c++)
                {
                    Console.Write(" ");
                    if (r == 0)
                    {
                        if (c == 0) { Console.Write("  "); }
                        else
                        {
                            Console.Write($"{c:D2}"); //:D2
                        }
                        continue;
                    }
                    if (c == 0)
                    {
                        Console.Write($"{r:D2}");
                        continue;
                    }
                    bool isFilled = false;
                    for (int index = 0; index < gomokuEngine.Stones.Length; index++)
                    {  
                        if (gomokuEngine.Stones[index].Row+1 == r && gomokuEngine.Stones[index].Column+1 == c)
                        {
                            if (gomokuEngine.Stones[index].IsBlack)
                            {
                                Console.Write("X ");
                            }
                            else
                            {
                                Console.Write("O ");
                            }
                            isFilled = true;
                        }
                    }
                    if (!isFilled)
                    {
                        Console.Write("__");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
