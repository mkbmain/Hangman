using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hangman
{
    class Program
    {
        private static int score = 0;
        private static string[] _words;
        private static Random _random = new Random(Guid.NewGuid().GetHashCode());

        private static readonly Dictionary<char, bool> AllowedLetters = "abcdefghijklmnopqrstuvwxyz"
            .ToCharArray()
            .ToDictionary(f => f, f => true);

        private static void Main()
        {
            _words = File.ReadAllLines(Path.Join(Environment.CurrentDirectory, "words.txt"))
                .Where(f => !f.Contains(".") && !f.Contains("'")).ToArray();
            Game();
        }


        static void Game()
        {
            var word = _words[_random.Next(0, _words.Length)].ToLower();
            var characters = word.ToCharArray().Select(f => '_').ToArray();

            int life = 5;
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
            Console.Write("Make a guess:");
            var read = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(read) || read.Length > 1 ||
                !AllowedLetters.ContainsKey(read.ToLower().First()))
            {
                Console.WriteLine("only 1 letter at a time");
                return GetGuessFromUser(previous);
            }

            char c = read.ToLower().First();
            if (previous.Contains(c))
            {
                Console.WriteLine("already Guessed have another go");
                return GetGuessFromUser(previous);
            }

            return c;
        }
    }
}