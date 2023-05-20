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

            static void Game() {

                List<string> list = new List<string>() { "Milk", "Books", "Paper", "Watermellon", "Rabbit" };

                Random rng = new Random();

                string randomWord = list[rng.Next(list.Count)];

                List<string> letters = new List<string>();

                int guesses = 0;

                while (guesses < MAX_GUESSES)
                {
                    int charToGuess = 0;

                    foreach (char character in randomWord.ToLower())
                    {

                        string letter = character.ToString();

                        if (letters.Contains(letter))
                        {
                            Console.Write(letter);
                        }
                        else
                        {
                            Console.Write("_");
                            charToGuess++;
                        }
                    }
                    Console.WriteLine(string.Empty);

                    if (charToGuess == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Congratulations. You won in {guesses} tries \nThe word was {randomWord}");
                        break;
                    }

                    Console.WriteLine($" You have only {MAX_GUESSES - guesses} guesses. ");
                    Console.Write("Type a letter!  ");

                    string input = Console.ReadKey().Key.ToString().ToLower();

                    letters.Add(input);

                    if (!randomWord.Contains(input))
                    {
                        guesses++;
                    }
                    Console.Clear();
                    if (guesses >= MAX_GUESSES)
                    {
                        Console.WriteLine("You lost \nYou have no more tries left");
                        Console.WriteLine($"The word was {randomWord}");
                    }
                }
            };

            string question = "y";



            while (question == "y")
            {
                Game();
                Console.WriteLine("Would you like to play again!");
                Console.WriteLine("Choose yes or no");
                Console.WriteLine("y/n");
                question = Console.ReadKey().Key.ToString().ToLower();
                Console.Clear();
                
            }

        }
    }
}