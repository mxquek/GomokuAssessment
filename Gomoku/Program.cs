using Gomoku.Game;
using Gomoku.Players;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayTitle();
            IPlayer player1,player2;
            const int MaxNumPlayers = 2;

            player1 = ReturnPlayerType(MaxNumPlayers, 1);
            player2 = ReturnPlayerType(MaxNumPlayers, 2);
            GomokuEngine gomokuengine = new GomokuEngine(player1, player2);

            DisplayMessage($"\n(Randomizing)\n\n{gomokuengine.Current.Name} goes first.");
        }

        static void DisplayTitle()
        {
            System.Console.WriteLine(
                "Welcome to Gomoku!\n" +
                "==================");
        }
        static void DisplayPlayerMenu(int playerNum)
        {
            System.Console.Write($"Player {playerNum} is:\n1. Human\n2. Random Player\nSelect [1-2]: ");
        }
        static void DisplayMessage(string message)
        {
            System.Console.Write(message);
        }

        static IPlayer ReturnPlayerType(int max, int playerNum)
        {
            int result = 0;
            bool valid = false;
            IPlayer player;
            while (!valid)
            {
                DisplayPlayerMenu(playerNum);
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
                    DisplayMessage($"\nPlayer {playerNum}, enter your name: ");
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
