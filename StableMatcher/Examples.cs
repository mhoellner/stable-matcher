namespace StableMatcher
{
    public static class Examples
    {
        public static readonly int[,] Moodle3Men = {
            { 1, 0, 2 },
            { 2, 1, 0 },
            { 0, 2, 1 }
        };

        public static readonly int[,] Moodle3Women = Moodle3Men;

        public static readonly int[,] Moodle5Men = {
            { 0, 1, 4, 3, 2 },
            { 1, 4, 3, 0, 2 },
            { 4, 1, 0, 2, 3 },
            { 3, 0, 1, 2, 4 },
            { 4, 3, 1, 2, 0 }
        };
        public static readonly int[,] Moodle5Women = {
            { 2, 1, 3, 0, 4 },
            { 3, 4, 0, 1, 2 },
            { 1, 2, 3, 4, 0 },
            { 0, 1, 2, 4, 3 },
            { 0, 1, 4, 2, 3 }
        };
        public static readonly int[,] SampleMen = {
            { 1, 4, 0, 2, 3 },
            { 0, 1, 2, 3, 4 },
            { 1, 2, 4, 3, 0 },
            { 0, 2, 1, 3, 4 },
            { 4, 2, 1, 0, 3 }
        };
        public static readonly int[,] SampleWomen = {
            { 4, 0, 3, 1, 2 },
            { 3, 4, 1, 0, 2 },
            { 0, 3, 1, 2, 4 },
            { 2, 1, 3, 0, 4 },
            { 3, 1, 2, 4, 0 }
        };
    }
}