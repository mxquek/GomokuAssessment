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
        const int MAXPLAYERS = 2;
        public bool Run()
        { 
            io.DisplayTitle();
            IPlayer player1, player2;
            Result result;
            bool startGame = true, isPlaying = true, valid = false;

            player1 = ReturnPlayerType(MAXPLAYERS, 1);
            player2 = ReturnPlayerType(MAXPLAYERS, 2);
            GomokuEngine gomokuEngine = new GomokuEngine(player1, player2);

            io.Display($"\n(Randomizing)\n\n{gomokuEngine.Current.Name} goes first.");
            while (isPlaying)
            {
                result = PromptMove(gomokuEngine);
                io.PrintBoard(gomokuEngine);
                io.Display(result.Message);
                if (gomokuEngine.IsOver == true)
                {
                    isPlaying = false;
                }
            }
            while (!valid)
            {
                io.Display($"\nPlay Again? [y/n]: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        valid = true;
                        startGame = true;
                        break;
                    case "n":
                        valid = true;
                        startGame = false;
                        break;
                    default:
                        io.Display("Invalid Response.");
                        break;
                }
             }
            return startGame;
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
                    io.Display($"\nPlayer {playerNum}, enter your name: ");
                    player = new HumanPlayer(System.Console.ReadLine()); ;
                    break;
                default:
                    player = new RandomPlayer();
                    break;
            }

            return player;

        }
        internal Result PromptMove(GomokuEngine gomokuEngine)
        {
            bool valid = false;
            Stone stone;
            Result result=null;
            while (!valid)
            {
                io.Display($"\n{gomokuEngine.Current.Name}'s Turn\n");
                if (gomokuEngine.Current.GetType() == typeof(RandomPlayer))
                {
                    stone = gomokuEngine.Current.GenerateMove(gomokuEngine.Stones);
                    io.Display($"Row: {stone.Row}\nColumn:{stone.Column}\n");
                    io.Display("\nPress any key to continue.\n");
                    Console.ReadKey();
                }
                else
                {
                    io.Display($"Enter a row: ");
                    int row = int.Parse(Console.ReadLine());
                    io.Display("Enter a column: ");
                    int column = int.Parse(Console.ReadLine());
                    stone = new Stone(row - 1, column - 1, gomokuEngine.IsBlacksTurn);
                }

                result = gomokuEngine.Place(stone);
                if (result.IsSuccess == true)
                {
                    valid = true;
                }
                else
                {
                    io.Display(result.Message);
                    continue;
                }
            }
            return result;
            
        }
    }
}
