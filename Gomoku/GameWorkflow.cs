using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Game;
using Gomoku.Players;

namespace Gomoku
{
    class GameWorkflow
    {
        public ConsoleIO io = new ConsoleIO();
        public void Run()
        {
            
            io.DisplayTitle();
            IPlayer player1, player2;
            const int MAXPLAYERS = 2;
            int row = 0, column = 0;
            bool valid = false;
            Result result;
            Stone stone;

            player1 = ReturnPlayerType(MAXPLAYERS, 1);
            player2 = ReturnPlayerType(MAXPLAYERS, 2);
            GomokuEngine gomokuEngine = new GomokuEngine(player1, player2);

            io.DisplayMessage($"\n(Randomizing)\n\n{gomokuEngine.Current.Name} goes first.");

            while (!valid)
            {
                io.DisplayMessage($"\n{gomokuEngine.Current.Name}'s Turn\nEnter a row: ");
                row = int.Parse(Console.ReadLine());
                io.DisplayMessage("Enter a column: ");
                column = int.Parse(Console.ReadLine());
                
                stone = new Stone(row-1, column-1, true);

                result = gomokuEngine.Place(stone);
                if(result.IsSuccess == true)
                {
                    valid = true;
                }
                else
                {
                    io.DisplayMessage(result.Message);
                }
            }

            io.PrintBoard(gomokuEngine);

        }

        internal IPlayer ReturnPlayerType(int max, int playerNum)
        {
            int result = 0;
            bool valid = false;
            IPlayer player;
            while (!valid)
            {
                io.DisplayPlayerMenu(playerNum);
                if (int.TryParse(System.Console.ReadLine(), out result) && result <= max && result > 0)
                {
                    valid = true;
                    continue;
                }
                else
                {
                    System.Console.WriteLine("Invalid Input!");
                }
            }

            switch (result)
            {
                case 1:
                    io.DisplayMessage($"\nPlayer {playerNum}, enter your name: ");
                    player = new HumanPlayer(System.Console.ReadLine()); ;
                    break;
                default:
                    player = new RandomPlayer();
                    break;
            }

            return player;

        }
    }
}
