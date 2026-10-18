using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class HangManLibrary
    {
        private readonly List<string> _wordList = new List<string> // Private list so the other classes and methods cant modify it.
        {
            // 5 letters
            "block",
            "frost",
            "skaft",
            "gripa",
            "skift",

            // 7 letters
            "kattunge",
            "borstar",
            "fönster",
            "tallrik",
            "kryddor",

            // 9 letters
            "solnedgång",
            "beundrare",
            "hippodrom",
            "meddelande",
            "brandlarm"
        };

        public string GetRandomWord(int length) // Method returns a random word from <wordList>. Will get length from switch case in HangManEngine.
        {
            List<string> filteredWords = new List<string>(); // Create a new list.

            foreach (string word in _wordList) // Foreach word in my original list that contains that number of letters.
            {
                if (word.Length == length)
                {
                    filteredWords.Add(word); // Add it to filteredWords list.
                }
            }

            Random rnd = new Random(); // Creating the random function.
            int index = rnd.Next(filteredWords.Count); // Get a random number between 0 and number of words in filteredWords. Put in index.

            return filteredWords[index]; // Return the word from the random number index place.
        }
    }
}