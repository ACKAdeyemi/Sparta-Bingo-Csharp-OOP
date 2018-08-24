using System;

namespace Bingo
{
    class Program
    {
        // To run the game you now have to run it through the exe when built and give it arguments
        // This is what we recommend: 75, 5, 5, 15
        // So ConsoleApp1.exe 75 5 5 15 
        static void Main(string[] args)
        {
            // To execute from command line:
            Game game = new Game(Convert.ToInt32(args[0]));
            Card card = new Card(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]));

            // To execute inside Visual Studio and run debugger:
            //Game game = new Game(75);
            //Card card = new Card(1, 5, 15);

            game.MakeBalls();
            card.ConfirmCard();
            game.DrawBalls();
            Console.ReadLine();
        }
    }
}
