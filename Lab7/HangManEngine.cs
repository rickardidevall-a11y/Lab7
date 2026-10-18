using System;
using System.Collections.Generic;

namespace Lab7
{
    public class HangManEngine
    {
        private HangManLibrary _library;          // Library instance to get random words.
        private string _secretWord;               // The actual word the player needs to guess.
        private char[] _maskedWord;               // Masked version of the word (example: _____).
        private HashSet<char> _guessedLetters;    // Stores guessed letters so we don't guess twice.
        private int _wrongGuesses;                // Counts wrong guesses.

        public bool GameOver { get; private set; } // True when player wins or loses.

        public HangManEngine()
        {
            _library = new HangManLibrary();       // Create a new Library instance.
            _guessedLetters = new HashSet<char>(); // Create a new HashSet for guessed letters.
            _wrongGuesses = 0;                     // Start with 0 wrong guesses.
            GameOver = false;                      // Game is not over at start.
        }

        // Starts a new game with a word of chosen length.
        public void StartGame(int wordLength)
        {
            _secretWord = _library.GetRandomWord(wordLength); // Get random word from Library.

            // Create masked version of the word (example: "_____").
            _maskedWord = new string('_', _secretWord.Length).ToCharArray();

            _guessedLetters.Clear(); // Clear guessed letters from previous games.
            _wrongGuesses = 0;       // Reset wrong guesses.
            GameOver = false;        // Reset game over flag.

            Console.WriteLine("Spelet startar!");
            Console.WriteLine($"Ordet har {_secretWord.Length} bokstäver.");
            Console.WriteLine(new string(_maskedWord));
        }

        // Method for guessing a letter.
        public void GuessLetter(char letter)
        {
            if (GameOver) return; // If game is already over, ignore guesses.

            letter = char.ToLower(letter); // Always convert to lowercase.

            // Check if letter has already been guessed.
            if (_guessedLetters.Contains(letter))
            {
                Console.WriteLine("Du har redan gissat den bokstaven.");
                return;
            }

            _guessedLetters.Add(letter); // Add letter to guessed list.

            // Check if letter exists in the secret word.
            if (_secretWord.Contains(letter))
            {
                // Reveal the letter in the masked word.
                for (int i = 0; i < _secretWord.Length; i++)
                {
                    if (_secretWord[i] == letter)
                    {
                        _maskedWord[i] = letter; // Replace '_' with correct letter.
                    }
                }

                Console.WriteLine("Rätt gissat!");
                Console.WriteLine(new string(_maskedWord));
            }
            else
            {
                _wrongGuesses++; // Increase wrong guess counter.
                Console.WriteLine("Fel gissat!");
                DrawHangman();   // Draw hangman based on wrong guesses.
            }

            CheckGameStatus(); // Check if game is won or lost.
        }

        // Checks if the player has won or lost.
        private void CheckGameStatus()
        {
            // If masked word matches secret word, player wins.
            if (new string(_maskedWord) == _secretWord)
            {
                Console.WriteLine("Du vann!");
                GameOver = true;
            }
            // If too many wrong guesses, player loses.
            else if (_wrongGuesses >= 8)
            {
                Console.WriteLine("Du förlorade!");
                Console.WriteLine($"Ordet var: {_secretWord}");
                GameOver = true;
            }
        }

        // Draws the hangman depending on wrong guesses.
        private void DrawHangman()
        {
            // This ASCII hangman drawing was inspired by AI suggestions,
            // but simplified and adjusted manually to fit assignment requirements.
            switch (_wrongGuesses)
            {
                case 1:
                    Console.WriteLine("_______");
                    break;
                case 2:
                    Console.WriteLine("  |\n  |\n  |\n_______");
                    break;
                case 3:
                    Console.WriteLine("______\n  |\n  |\n  |\n_______");
                    break;
                case 4:
                    Console.WriteLine("______\n  |   |\n  |\n  |\n_______");
                    break;
                case 5:
                    Console.WriteLine("______\n  |   |\n  |   O\n  |\n_______");
                    break;
                case 6:
                    Console.WriteLine("______\n  |   |\n  |   O\n  |   |\n_______");
                    break;
                case 7:
                    Console.WriteLine("______\n  |   |\n  |   O\n  |  /|\\\n_______");
                    break;
                case 8:
                    Console.WriteLine("______\n  |   |\n  |   O\n  |  /|\\\n  |  / \\\n_______");
                    break;
            }
        }
    }
}