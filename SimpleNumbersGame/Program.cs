using System;
namespace NumbersGame

// Noah Hoff NET24 
// NumbersGame
// This is a game where players guess a randomly generated number.
// Number range and number of guesses varies depending on chosen difficulty.

{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true; 
            while (run) // keeps program running until run = false
            {
                Console.Clear(); // clears console before printing menu
                run = printMenu(); 
            }
        }
        static bool printMenu() // prints menu, returns false to main if user decides to terminate the program
        {
            Console.WriteLine("-------MENY-------");
            Console.WriteLine("[1] Spela");
            Console.WriteLine("[2] Svårighetsgrad");
            Console.WriteLine("[3] Avsluta");
            int choice = validInput(1, 3); // validInput takes and checks user input, stores it in variable choice
            Console.Clear();
            switch (choice) // user selects case 1-3 from menu
            {
                case 1: // starts the game immediately on easy settings. 
                    gamePlay(1, 20, 10, "att spela, du får svårighetsgraden lätt");
                    break;
                case 2: // prints difficulty menu, user decide which difficulty to choose.
                    difficulty();
                    break;
                case 3: // return false to main, which
                    Console.WriteLine("Programmet avslutas...");
                    Thread.Sleep(1000); //pauses program for a sec to let the user read before the program shuts down
                    return false;

                default: // failsafe in case if something gets past the validInput method
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
            return true; // return true to main to keep the program going.
        }
        static void difficulty() //prints difficulty menu
        {
            Console.WriteLine("--Välj Svårighetsgrad--");
            Console.WriteLine("[1] Lätt");
            Console.WriteLine("[2] Medium");
            Console.WriteLine("[3] Extremt Svår");
            int difficultyChoice = validInput(1, 3); // validInput takes and checks user input, stores it in variable difficultyChoice
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
                default: // failsafe in case if something gets past the validInput method
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }

        }
        static void gamePlay(int min, int max, int guesses, string difficulty) // game logic
        {
            Console.Clear();
            Console.WriteLine($"Välkommen! Du valde {difficulty}.");
            Console.WriteLine($"Jag tänker på ett nummer. Kan du gissa vilket? du får {guesses} gissningar.");
            Console.WriteLine("");
            Random random = new Random(); // call Random class
            int guess = 0; 
            int number = random.Next(min, max); // create random number between min/max, varies depending on difficulty
            while (!(guess == number || guesses == 0)) // loop continues until user guesses right, or runs out of guesses
            {
                guess = validInput(min, max); 
                Console.Clear(); // clears console after each guess
                if (guess > number) // checks if the guess is smaller or larger than the the randomly generated number 
                {
                    if (guess - number < 5) //checks if the user is close to guessing it right
                    {
                        Console.WriteLine($"Du gissade {guess}, vilket är lite för högt.");
                    }
                    else
                    {
                        Console.WriteLine($"Du gissade {guess}, vilket är väldigt högt.");
                    }
                }
                else
                {
                    if (number - guess < 5)
                    {
                        Console.WriteLine($"Du gissade {guess}, vilket är lite för lågt.");
                    }
                    else
                    {
                        Console.WriteLine($"Du gissade {guess}, vilket är väldigt lågt.");
                    }
                }
                Console.WriteLine($"Du har {guesses - 1} gissningar kvar."); // displays guesses left
                Console.WriteLine("");
                guesses--;
            }

            if (guess == number) // checks if player won or lost
            {
                Console.Clear();
                Console.WriteLine("Du vann, rätt svar var: " + number);
                Console.ReadKey();
                return; 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du förlorade, rätt svar var: " + number);
                Console.ReadKey();
                return;
            }

        }
        public static int validInput(int min, int max) 
        {
            string input;
            int number;
            do
            {
               Console.Write($"Skriv en siffra, {min}-{max}: ");
               input = Console.ReadLine(); //puts user input in a string variable

            } while (!int.TryParse(input, out number) || number < min || number > max); // check if that string can be converted to an int within the parameters
            return number; //return the interger in number variable
        }

    }
}
