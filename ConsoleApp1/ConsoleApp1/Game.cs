using System;
using System.Collections.Generic;

namespace Bingo
{
    class Game
    {
        public int numberOfBalls;
        public List<Ball> balls = new List<Ball>();
        public int ownNumbersCalled = 0;
        public List<Ball> chosenBalls = new List<Ball>();

        public Game(int _numberOfBalls)
        {
            numberOfBalls = _numberOfBalls;
            Console.WriteLine("Welcome to Bingo!\nThe aim is to match all your numbers within 50 rolls to win - GOOD LUCK!\n");
        }

        public void MakeBalls()
        {
            Console.WriteLine("\nLoading balls into game...");
            for (int i = 1; i <= numberOfBalls; i++)
            {
                balls.Add(new Ball(i));
            }
        }

        public void DrawBalls()
        {
            for (int score = 1; score <= 50; score++)
            {
                // Randomly selects one of the remaining numbers
                Random rnd = new Random();

                Ball ball = balls[rnd.Next(balls.Count)];

                Console.WriteLine("\nThe {0}th number is {1}", score, ball.number);

                chosenBalls.Add(ball);

                // Check the ball that was just drawn against what is on your card
                ownNumbersCalled = CheckNumberWasCalled(ball, ownNumbersCalled);

                if (ownNumbersCalled == Card.bingoCardSize && score == 50)
                {
                    Console.WriteLine("\nGame finished! It took you {0} turns to win.", score + 1);
                }
                else if (ownNumbersCalled != Card.bingoCardSize && score == 50)
                {
                    Console.WriteLine("\nSorry, you didn't win this time round. \nYou only managed to match {0} numbers out of {1} balls.\nYou needed {2} to win.", ownNumbersCalled, score, Card.bingoCardSize);
                }

                // Removes the randomly selected number
                balls.Remove(ball);
            }
        }

        public int CheckNumberWasCalled(Ball ball, int ownNumbersCalled)
        {
            for (var row = 0; row < Card.rows; row++)
            {
                for (var col = 0; col < Card.cols; col++)
                {
                    if (Card.bingoCard[row, col].Equals(ball.number))
                    {
                        Console.WriteLine("Got that!");
                        ownNumbersCalled++;
                        Console.WriteLine("You have had {0} numbers so far", ownNumbersCalled);
                    }
                }
            }
            return ownNumbersCalled;
        }
    }
}
