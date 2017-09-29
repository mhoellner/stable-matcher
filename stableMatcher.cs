using System;

namespace StableMatcher
{
    public class StableMatcher
    {
        public static void Main()
        {
            Console.WriteLine("Gale-Shapley Stable Matching algorithm");
            int[,] menPrefs = Examples.Moodle5Men; //SampleMen;
            int[,] womenPrefs = Examples.Moodle5Women; //SampleWomen;

            Console.WriteLine("Show preferences for men");
            ShowPrefs(menPrefs);
            Console.WriteLine("Show preferences for women");
            ShowPrefs(womenPrefs);

            int[] fiancee = Utils.FindStableMatchesUsingGaleShapleyAlgorithm(menPrefs, womenPrefs);
            //show results            
            Console.WriteLine("Solution to stable matching problem:");
            for (int i = 0; i < fiancee.Length; i++)
            {
                Console.Write("W{0}-M{1}, ", i + 1, fiancee[i] + 1);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void ShowPrefs(int[,] prefs)
        {
            int size = prefs.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                Console.Write("{0}: ", row + 1);
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0} ", prefs[row, col] + 1);
                }
                Console.WriteLine("");
            }
        }
    }
}