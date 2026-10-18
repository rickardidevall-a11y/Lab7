//Rickard Idevall NET26
using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            HangManEngine engine = new HangManEngine(); // Create engine instance.
            bool running = true; // Controls main menu loop.

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Hänga Gubbe ===");
                Console.WriteLine("1. Starta nytt spel");
                Console.WriteLine("2. Avsluta");
                Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Välj ordlängd:");
                    Console.WriteLine("1. 5 bokstäver");
                    Console.WriteLine("2. 7 bokstäver");
                    Console.WriteLine("3. 9 bokstäver");
                    Console.Write("Ditt val: ");

                    string lengthChoice = Console.ReadLine();
                    int wordLength = 0;

                    switch (lengthChoice)
                    {
                        case "1": wordLength = 5; break;
                        case "2": wordLength = 7; break;
                        case "3": wordLength = 9; break;
                        default:
                            Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                            Console.ReadKey();
                            continue;
                    }

                    engine.StartGame(wordLength);

                    while (!engine.GameOver)
                    {
                        Console.Write("Gissa en bokstav: ");
                        string input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
                        {
                            Console.WriteLine("Du måste skriva exakt EN bokstav.");
                            continue;
                        }

                        char letter = input[0];
                        engine.GuessLetter(letter);
                    }

                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                    Console.ReadKey();
                }
            }
        }
    }
}