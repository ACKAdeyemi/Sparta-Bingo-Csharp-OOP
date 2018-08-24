using System;

namespace Bingo
{
    class Card
    {
        public static int rows;
        public static int cols;
        public static int bingoCardSize;
        public int segmentSize;
        public static int[,] bingoCard;


        public Card(int _rows, int _cols, int _segmentSize)
        {
            rows = _rows;
            cols = _cols;
            segmentSize = _segmentSize;

            bingoCardSize = _rows * _cols;
            bingoCard = new int[_rows, _cols];
            PopulateCard();
        }


        public void PopulateCard()
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    bool isValid = false;

                    while (isValid == false)
                    {

                        int nthNumber = (row * cols) + (col);
                        int lowerBound = CreateLowerBound(row, col);
                        int upperBound = CreateUpperBound(row, col);

                        Console.WriteLine("Select your {0}th number between {1} and {2}.", nthNumber + 1, lowerBound, upperBound);
                        try
                        {
                            int candidate = int.Parse(Console.ReadLine());

                        isValid = CheckValid(candidate, upperBound, lowerBound);
                        if (isValid == true)
                        {
                            bingoCard[row, col] = candidate;
                        }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Got unexpected character, expecting number");
                            Console.WriteLine("\n\nCUSTOM MESSAGE: Exception for Developers:\n\n" + ex);
                        }


                    }
                }
            }
        }

        public bool CheckValid(int candidate, int upperBound, int lowerBound)
        {
            if ((candidate <= upperBound) && (candidate >= lowerBound) && (AlreadyChosen(candidate) == false))
            {
                bool valid_number = true;
                return valid_number;
            }
            else
            {
                Console.WriteLine("The number you entered is either outside the specified range or a repeated number.  Please choose again.");
                bool valid_number = false;
                return valid_number;
            }
        }

        public void ConfirmCard()
        {
            Console.WriteLine("\nYou have selected the following numbers:");
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write(bingoCard[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }

        public int CreateUpperBound(int row, int col)
        {
            double nthNumber = (row * cols) + (col);
            double rowD = row;
            double colD = col;
            double rowsD = rows;

            return Convert.ToInt32((Math.Ceiling((nthNumber + 1) / rowsD)) * segmentSize);
        }

        public int CreateLowerBound(int row, int col)
        {
            double nthNumber = (row * cols) + (col);
            double rowD = row;
            double colD = col;
            double rowsD = rows;

            return Convert.ToInt32(((Math.Floor(nthNumber / rowsD)) * segmentSize) + 1);
        }

        public bool AlreadyChosen(int candidate)
        {
            bool checkChosen = false;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (bingoCard[i, j].Equals(candidate))
                    {
                        checkChosen = true;
                    }
                }
            }
            return checkChosen;
        }
    }
}
