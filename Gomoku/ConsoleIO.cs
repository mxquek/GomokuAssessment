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
        public void DisplayMessage(string message)
        {
            System.Console.Write(message);
        }

        public void PrintBoard(GomokuEngine gomokuEngine)
        {
            for (int r = 0; r < GomokuEngine.WIDTH + 1; r++)
            {
                for (int c = 0; c < GomokuEngine.WIDTH + 1; c++)
                {
                    Console.Write(" ");
                    if (r == 0)
                    {
                        if (c == 0) { Console.Write("  "); }     //if [0,0]
                        else if (c < 10)
                        {
                            Console.Write($"0{c}");
                        }
                        else
                        {
                            Console.Write(c);
                        }
                        continue;
                    }
                    if (c == 0)
                    {
                        if (r < 10)
                        {
                            Console.Write($"0{r}");
                        }
                        else
                        {
                            Console.Write(r);
                        }
                        continue;
                    }

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
                        }
                        else
                        {
                            Console.Write("__");
                            //Console.Write($"{r}{c}");
                        }
                    }

                    //if board space empty, print __

                    //if board space is occupied by stone, print appropriate stone symbol
                    //for length of stone array,
                    //if stone.row == r && stone.column == c
                    //print X or O depending
                    //if(gomokuEngine.board[r,c])
                }
                Console.WriteLine("");
            }
        }
    }
}
