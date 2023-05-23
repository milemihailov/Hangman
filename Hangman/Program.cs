using System;
using System.Linq;

namespace Hangman
{
    internal class Program
    {
        const int MAX_GUESSES = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the HANGMAN game");
            Console.WriteLine($"Try to guess a word. You will have {MAX_GUESSES} tries");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Random rng = new Random();

            List<string> list = new List<string>() { "Milk", "Books", "Paper", "Watermellon", "Rabbit" };
            List<char> lettersFromUser = new List<char>();            // list of letters that user inputs

            string question = "y";                                    // variable to determine if the user wants to play more
            int guesses = 0;                                          // variable to keep track how much guesses are left

            while (question == "y")
            {
                string randomWord = list[rng.Next(list.Count)];           // getting a random word from list

                while (guesses < MAX_GUESSES)
                {
                    Console.Clear();
                    int charToGuess = 0;                             // variable that keeps track if you won the game

                    foreach (char character in randomWord)
                    {
                        if (lettersFromUser.Contains(Char.ToLower(character)))
                        {
                            Console.Write(character);
                        }
                        else
                        {
                            Console.Write("_");
                            charToGuess++;
                        }
                    }

                    if (charToGuess == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Congratulations. You won in {guesses} tries \nThe word was {randomWord}");
                        break;
                    }

                    Console.WriteLine($"\nYou have only {MAX_GUESSES - guesses} guesses. ");
                    Console.Write("Type a letter!  ");

                    char input = Char.ToLower(Console.ReadKey().KeyChar);       // get user input 

                    if (!lettersFromUser.Contains(input))
                    {
                        lettersFromUser.Add(input);                             // add user input to the list of char
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You already have chosen that letter. \nPress any key to continue.");
                        Console.ReadKey();
                        continue;
                    }

                    if (!randomWord.Contains(input))
                    {
                        guesses++;                // increment guesses if character is not guessed and not repeated
                    }

                    if (guesses >= MAX_GUESSES)
                    {
                        Console.Clear();
                        Console.WriteLine("You lost \nYou have no more tries left");
                        Console.WriteLine($"The word was {randomWord}");
                    }

                };
                Console.WriteLine("\nWould you like to play again!");
                Console.WriteLine("Choose yes or no");
                Console.WriteLine("y/n");
                question = Console.ReadKey().Key.ToString().ToLower();
                if (question == "y")
                {
                    guesses = 0;
                    lettersFromUser.Clear();
                }
                
            }

        }
    }
}