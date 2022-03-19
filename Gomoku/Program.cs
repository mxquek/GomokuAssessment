using Gomoku.Game;
using Gomoku.Players;
using System;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWorkflow gameWorkflow = new GameWorkflow();
            bool play = true;
            while (play)
            {
                play = gameWorkflow.Run();
            }
        }

        

       

        
    }
}
