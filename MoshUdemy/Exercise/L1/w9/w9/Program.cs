using System;
using System.IO; 

namespace w9
{
    internal class Program
    {
        // ex1, read text file and display the number of words
        public static void ex1()
        {
            string basePath = "C:\\cygwin64\\home\\nq9093\\CodeSpace\\CSharp\\Exercise\\w9\\w9\\text.txt"; 
            //string path = Directory.GetCurrentDirectory() + @"\test.txt";
            //string path = @"C:\Users\user\Desktop\test.txt";
            string text = File.ReadAllText(basePath);
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Number of words: " + words.Length);
        }

        // ex2, read text file and display the longest word
        public static void ex2()
        { 
            string basePath = "C:\\cygwin64\\home\\nq9093\\CodeSpace\\CSharp\\Exercise\\w9\\w9\\text.txt";
            string text = File.ReadAllText(basePath);
            string[] words = text.Split(' ');
            string longestWord = "";
            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            Console.WriteLine("Longest word: " + longestWord);
        }

        static void Main(string[] args)
        {
            ex2(); 
        }
    }
}
