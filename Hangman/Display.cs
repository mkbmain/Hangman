using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Display
    {
        public static void Output(int life,int score, char[] word, IEnumerable<char> guessed)
        {
            Console.Clear();
            Console.WriteLine("score:" + score);
            Console.WriteLine(Hangmans[6 - life - 1]);
            Console.WriteLine($"Guessed: {string.Join(",", guessed)}");
            Console.WriteLine($"The word is {word.Length} letters long : {string.Join("", word)}");
        }
        
        private static readonly string[] Hangmans = {
            $@"        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine}        ",
            $@"        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@"        {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |    + {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |    + {Environment.NewLine} |   / \"
        };
    }
}