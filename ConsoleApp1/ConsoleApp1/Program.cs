using System;
using System.Linq;

namespace StringOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize the input string and continueProgram flag
            string input = string.Empty;
            bool continueProgram = true;

            // continue to prompt user for input and operations until continueProgram is false
            while (continueProgram)
            {
                // prompt user to enter a string and read user input
                Console.Write("Enter a string: ");
                input = Console.ReadLine();

                bool continueOperations = true;

                while (continueOperations)
                {
                    // display the operations menu
                    Console.WriteLine("\nOperations Menu:");
                    Console.WriteLine("1. Convert a string to uppercase");
                    Console.WriteLine("2. Reverse a string");
                    Console.WriteLine("3. Count the number of vowels in a string");
                    Console.WriteLine("4. Count the number of words in a string");
                    Console.WriteLine("5. Convert a string to title case");
                    Console.WriteLine("6. Check if a string is a palindrome");
                    Console.WriteLine("7. Find the longest and shortest words in a string");
                    Console.WriteLine("8. Find the most frequent word in a string");
                    Console.WriteLine("9. Find only the duplicate characters in a string");
                    Console.WriteLine("0. Quit");

                    // prompt user to enter an option and read user input
                    Console.Write("Enter an option: ");
                    int option = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    // perform the selected operation based on the user's option
                    switch (option)
                    {
                        case 1:  // Convert the string to uppercase
                            input = input.ToUpper();
                            Console.WriteLine($"Result: {input}");
                            break;

                        case 2:  // Reverse string
                            input = new string(input.Reverse().ToArray());
                            Console.WriteLine($"Result: {input}");
                            break;

                        case 3:  // Count the number of vowels
                            int vowelCount = input.Count(c => "AEIOUaeiou".Contains(c));
                            Console.WriteLine($"The string has {vowelCount} vowels");
                            break;

                        case 4:  // Count the number of words in the string
                            int wordCount = input.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                            Console.WriteLine($"The string has {wordCount} words");
                            break;

                        case 5: //Convert the string to title case
                            input = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
                            Console.WriteLine($"Result: {input}");
                            break;

                        case 6:  // Check if the string is a palindrome
                            bool isPalindrome = true;
                            for (int i = 0; i < input.Length / 2; i++)
                            {
                                if (input[i] != input[input.Length - i - 1])
                                {
                                    isPalindrome = false;
                                    break;
                                }
                            }
                            Console.WriteLine($"Result: {isPalindrome}");
                            break;

                        case 7:   // Find the longest and shortest words in the string 
                            var words = input.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            Console.WriteLine($"Longest word: {words.OrderByDescending(w => w.Length).First()}");
                            Console.WriteLine($"Shortest word: {words.OrderBy(w => w.Length).First()}");
                            break;

                        case 8:  // Find the most frequent word in the string
                            var freq = input.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .GroupBy(w => w)
                                .OrderByDescending(g => g.Count())
                                .First()
                                .Key;
                            Console.WriteLine($"The most frequent word is {freq}");
                            break;

                        case 9:  // Find only the duplicate characters
                            var duplicateChars = input.Replace(" ", "")
                                .GroupBy(c => c)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key);
                            Console.WriteLine($"Result: {string.Join(",", duplicateChars)}");
                            break;

                        case 0:
                            continueOperations = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
