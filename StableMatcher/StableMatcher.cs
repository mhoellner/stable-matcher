using System;
using System.Diagnostics.CodeAnalysis;

namespace StableMatcher
{
    [ExcludeFromCodeCoverage]
    public class StableMatcher
    {
        public static void Main()
        {
            Console.WriteLine("Gale-Shapley Stable Matching algorithm");
            var proposerPrefs = FileOrExampleSwitcher();
            var accepterPrefs = FileOrExampleSwitcher();

            Console.WriteLine("Show preferences for proposers (P)");
            DisplayPreferences(proposerPrefs);
            Console.WriteLine("Show preferences for accepters (A)");
            DisplayPreferences(accepterPrefs);

            int[] fiancee;
            try
            {
                fiancee = GaleShapleyAlgorithm.FindStableMatches(proposerPrefs, accepterPrefs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
             
            //show results            
            Console.WriteLine("Solution to stable matching problem:");
            for (int i = 0; i < fiancee.Length; i++)
            {
                Console.Write("P{0}-A{1}, ", i + 1, fiancee[i] + 1);
            }
        }

        /// <summary>
        /// Displays the ranked array
        /// </summary>
        /// <param name="prefs"></param>
        private static void DisplayPreferences(int[,] prefs)
        {
            int size = prefs.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                Console.Write("   {0}: ", row + 1);
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0} ", prefs[row, col] + 1);
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Switch between initializing the array from a file and from an example
        /// </summary>
        /// <returns></returns>
        private static int[,] FileOrExampleSwitcher()
        {
            Console.Write("Do you want to use a file (f) or an existing example (e)? ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "e":
                    return ExampleSwitcher();
                case "f":
                    return ReadFromFile();
                default:
                    Console.WriteLine("That is not a valid input.");
                    return FileOrExampleSwitcher();
            }
        }

        /// <summary>
        /// Initializes the array from a file
        /// </summary>
        /// <returns></returns>
        private static int[,] ReadFromFile()
        {
            Console.Write("Please give the absolute path to your file: ");
            var input = Console.ReadLine();
            try
            {
                return Preferences.GetPreferencesFromFile(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadFromFile();
            }
        }

        /// <summary>
        /// Initializes the array from an example
        /// </summary>
        /// <returns></returns>
        private static int[,] ExampleSwitcher()
        {
            Console.WriteLine("(1) Moodle 3 Men");
            DisplayPreferences(Examples.Moodle3Men);
            Console.WriteLine("(2) Moodle 3 Women");
            DisplayPreferences(Examples.Moodle3Women);
            Console.WriteLine("(3) Moodle 5 Men");
            DisplayPreferences(Examples.Moodle5Men);
            Console.WriteLine("(4) Moodle 5 Women");
            DisplayPreferences(Examples.Moodle5Women);
            Console.WriteLine("(5) Sample 5 Men");
            DisplayPreferences(Examples.SampleMen);
            Console.WriteLine("(6) Sample 5 Women");
            DisplayPreferences(Examples.SampleWomen);

            while (true)
            {
                Console.Write("Choose an Example: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return Examples.Moodle3Men;
                    case "2":
                        return Examples.Moodle3Women;
                    case "3":
                        return Examples.Moodle5Men;
                    case "4":
                        return Examples.Moodle5Women;
                    case "5":
                        return Examples.SampleMen;
                    case "6":
                        return Examples.SampleWomen;
                    default:
                        Console.WriteLine("The input was invalid.");
                        continue;
                }
            }
        }
    }
}