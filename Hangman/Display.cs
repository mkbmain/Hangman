using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Display
    {
        public static void Output(int life,int score, char[] word, IEnumerable<char> guessed)
        {
            Console.Clear();
            Console.WriteLine("score:" + score);
            Console.WriteLine(Hangmans[Program.MaxLife - life ]);
            Console.WriteLine($"life left :{life}");
            Console.WriteLine($"Guessed: {string.Join(",", guessed.OrderBy(f=> f))}");
            Console.WriteLine($"The word is {word.Length} letters long : {string.Join("", word)}");
        }
        
        private static readonly string[] Hangmans = {
            $@"        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine}        ",
            $@"        {Environment.NewLine}        {Environment.NewLine}        {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@"        {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |      {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |      {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |    + {Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |   -+-{Environment.NewLine} |      ",
            $@" .......{Environment.NewLine} |    | {Environment.NewLine} |    0 {Environment.NewLine} |   -+-{Environment.NewLine} |   / \"
        };
    }
}