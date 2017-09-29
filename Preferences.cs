using System.IO;

namespace StableMatcher
{
    public static class Preferences
    {
        public static int[,] GetPreferencesFromFile(string absolutePath)
        {
            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException();
            }

            var file = File.Open(absolutePath, FileMode.Open);
            var reader = new StreamReader(file);
            int[,] array = { };
            var isFirstLine = true;
            var personIndex = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    var items = line.Split(' ');

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        array = new int[items.Length, items.Length];
                    }

                    var prefIndex = 0;
                    foreach (var item in items)
                    {
                        int parsed;
                        if (int.TryParse(item, out parsed))
                        {
                            if (parsed < 0 || parsed >= items.Length)
                            {
                                throw new FileLoadException();
                            }
                            array[personIndex, prefIndex] = parsed;
                            prefIndex++;
                        }
                        else
                        {
                            throw new FileLoadException();
                        }
                    }
                }
                personIndex++;
            }
            return array;
        }
    }
}