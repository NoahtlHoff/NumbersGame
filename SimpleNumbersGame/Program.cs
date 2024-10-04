using System;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                printMenu();
                int choice = validInput(1,3);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        gamePlay(1, 20, 10, "lätt");
                        break;
                    case 2:
                        difficulty();
                        break;
                    case 3:
                        return;

                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        break;
                }
            }


        }
        static void printMenu()
        {
            Console.WriteLine("-----Meny-----");
            Console.WriteLine("[1] Spela");
            Console.WriteLine("[2] Svårighetsgrad");
            Console.WriteLine("[3] Avsluta");
        }
        static void difficulty()
        {
            Console.WriteLine("--Välj Svårighetsgrad--");
            Console.WriteLine("[1] Lätt");
            Console.WriteLine("[2] Medium");
            Console.WriteLine("[3] Jättesvår");
            int difficultyChoice = validInput(1, 3);
            switch (difficultyChoice)
            {
                case 1:
                    gamePlay(1,20, 10, "lätt");
                    break;
                case 2:                   
                    gamePlay(1, 50, 5, "medium");
                    break;
                case 3:
                    gamePlay(1, 100, 5, "svår");
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }

        }
        static void gamePlay(int min, int max, int guesses, string difficulty)
        {
            Random random = new Random();
            bool playAgain = true;
            int number;
            int guess;
            while (playAgain)
            {
                Console.Clear();
                Console.WriteLine($"Du valde {difficulty}.");

                guess = 0;
                number = random.Next(min, max);
                while (!(guess == number || guesses == 0))
                {
                    Console.WriteLine($"Du har {guesses} gissningar kvar.");
                    guess = validInput(min, max);
                    Console.WriteLine("Gissning: " + guess);
                    Console.Clear();
                    if (guess > number)
                    {
                        if (guess - number < 5)
                        {
                            Console.WriteLine("Du gissade lite för högt");
                        }
                        else
                        {
                            Console.WriteLine("Du gissade väldigt högt");
                        }
                    }
                    else
                    {
                        if (number - guess < 5)
                        {
                            Console.WriteLine("Du gissade lite för lågt");
                        }
                        else
                        {
                            Console.WriteLine("Du gissade väldigt lågt");
                        }
                    }
                    guesses--;
                }
                if (guess == number)
                {
                    Console.WriteLine("Du vann, rätt svar var: " + number);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Du förlorade, rätt svar var: " + number);
                    Console.ReadKey();
                    return;
                }
            }

        }
        public static int validInput(int min, int max)
        {
            string input;
            int number;
            do
            {
               Console.Write($"Skriv en siffra, {min}-{max}: ");
               input = Console.ReadLine();

            } while (!int.TryParse(input, out number) || number < min || number > max);
            return number;
        }

    }
}
