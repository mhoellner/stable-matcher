namespace StableMatcher
{
    public static class Examples
    {
        public static readonly int[,] Moodle3Men = new int[3, 3]
        {
            { 1, 0, 2 },
            { 2, 1, 0 },
            { 0, 2, 1 }
        };
        public static readonly int[,] Moodle3Women = new int[3, 3]
        {
            { 1, 0, 2 },
            { 2, 1, 0 },
            { 0, 2, 1 }
        };
        public static readonly int[,] Moodle5Men = new int[5, 5]
        {
            { 0, 1, 4, 3, 2 },
            { 1, 4, 3, 0, 2 },
            { 4, 1, 0, 2, 3 },
            { 3, 0, 1, 2, 4 },
            { 4, 3, 1, 2, 0 }
        };
        public static readonly int[,] Moodle5Women = new int[5, 5]
        {
            { 2, 1, 3, 0, 4 },
            { 3, 4, 0, 1, 2 },
            { 1, 2, 3, 4, 0 },
            { 0, 1, 2, 4, 3 },
            { 0, 1, 4, 2, 3 }
        };
        public static readonly int[,] SampleMen = new int[5,5]
        {
            { 1, 4, 0, 2, 3 },
            { 0, 1, 2, 3, 4 },
            { 1, 2, 4, 3, 0 },
            { 0, 2, 1, 3, 4 },
            { 4, 2, 1, 0, 3 }
        };
        public static readonly int[,] SampleWomen = new int[5,5]
        {
            { 4, 0, 3, 1, 2 },
            { 3, 4, 1, 0, 2 },
            { 0, 3, 1, 2, 4 },
            { 2, 1, 3, 0, 4 },
            { 3, 1, 2, 4, 0 }
        };
    }
}