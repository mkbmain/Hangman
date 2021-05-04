using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;

namespace Hangman
{
    class Program
    {
        private static int score = 0;
        public const int MaxLife = 7;
        private static string[] _words;
        private static Random _random = new Random(Guid.NewGuid().GetHashCode());

        private static readonly Dictionary<char, bool> AllowedLetters = "abcdefghijklmnopqrstuvwxyz"
            .ToDictionary(f => f, f => true);

        private static void Main()
        {
            _words = File.ReadAllLines(Path.Join(Environment.CurrentDirectory, "words.txt"))
                .Select(f=> f.ToLower())
                .Where(f => f.All(f=> AllowedLetters.ContainsKey(f))).ToArray();
            Game();
        }


        static void Game()
        {
            var word = _words[_random.Next(0, _words.Length)];
            var characters = word.ToCharArray().Select(f => '_').ToArray();

            int life = MaxLife;
            var previous = new List<char>();
            while (true)
            {
                Display.Output(life, score, characters, previous);
                if (life == 0)
                {
                    score -= 10;
                    Console.WriteLine($"You lost word was {word}");
                    Console.ReadLine();
                    Game();
                }

                var guess = GetGuessFromUser(previous);
                previous.Add(guess);
                bool correct = false;
                for (int i = 0; i < word.Length; i++)
                {
                    var item = word[i];
                    if (item != guess)
                    {
                        continue;
                    }

                    characters[i] = item;
                    correct = true;
                    if (characters.Contains('_'))
                    {
                        continue;
                    }

                    score += 10;
                    Console.WriteLine($"You Win your word was{word}");
                    Console.ReadLine();
                    Game();
                }

                if (!correct)
                {
                    life--;
                }
            }
        }

        static char GetGuessFromUser(List<char> previous)
        {
            Console.Write("Guess a letter:");
            var read = Console.ReadLine()?.ToLower();
           
            if (string.IsNullOrWhiteSpace(read) ||
                read.Length > 1 ||
                !AllowedLetters.ContainsKey(read[0]) ||
                previous.Contains(read[0]))
            {
                Console.WriteLine("Please Enter 1 Letter that has not been already entered:");
                return GetGuessFromUser(previous);
            }
            
            return read[0];
        }
    }
}