namespace StableMatcher
{
    public static class Utils
    {
        /** Converts from a preference matrix to a ranked-preference matrix, i.e. 
         * converts from vector elements showing preferences sorted by column
         * to vector elements were each element shows their particular order in the array 
         * Example: Prefs = [4,0,3,1,2] -> RankedPrefs = [1,3,4,2,0]
         */
        public static int[,] GetRankedMatrixWithDummy(int[,] preferenceMatrix)
        {
            int size = preferenceMatrix.GetLength(1);

            //add extra column to rank for initialization with a dummy
            int[,] rank = new int[size, size + 1];

            //convert from a preference matrix to a ranked-preference matrix
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rank[i, preferenceMatrix[i, j]] = j;
                }
            }

            //initialize dummy column with largest possible value
            for (int i = 0; i < size; i++)
            {
                rank[i, size] = size;
            }

            return rank;
        }

        // Gale-Shapley Stable Matching Algorithm
        public static int[] FindStableMatchesUsingGaleShapleyAlgorithm(int[,] proposerPrefs, int[,] accepterPrefs)
        {
            int size = proposerPrefs.GetLength(1);
            int[,] rank = GetRankedMatrixWithDummy(accepterPrefs);

            //start stable marriage algorithm
            int[] fiancee = new int[size];
            int[] next = new int[size];  //to track the next in the list of women candidates

            for (int i = 0; i < size; i++)
            {  //start counters to zero index
                fiancee[i] = size;
                next[i] = -1;
            }

            for (int m = 0; m < size; m++)
            {
                int s = m;

                while (s != size)
                {
                    next[s] = next[s] + 1;
                    int w = proposerPrefs[s, next[s]];
                    if (rank[w, s] < rank[w, fiancee[w]])
                    {
                        int t = fiancee[w];
                        fiancee[w] = s;
                        s = t;
                    }
                }
            }

            return fiancee;
        }
    }
}