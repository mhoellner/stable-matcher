using System.IO;

namespace StableMatcher
{
    public static class Preferences
    {
        /// <summary>
        /// Opens the file provided by the absolutePath argument.
        /// Parses the SPACE separated integers into an array.
        /// </summary>
        /// <param name="absolutePath">The absolute path to the text file with the values.</param>
        /// <returns>The parsed values in the file in an array</returns>
        public static int[,] GetPreferencesFromFile(string absolutePath)
        {
            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException();
            }
            
            int[,] array = { };
            var isFirstLine = true;
            var personIndex = 0;

            using (var reader = new StreamReader(File.Open(absolutePath, FileMode.Open)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var items = line.Split(' ');

                        // initializes the array on the first iteration with the number of elements in the first line
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            array = new int[items.Length, items.Length];
                            for (var i = 0; i < items.Length; i++)
                            {
                                for (var j = 0; j < items.Length; j++)
                                {
                                    array[i, j] = -1;
                                }
                            }
                        }

                        // throws an error if the file has more lines with values than values in the first row
                        if (personIndex >= array.GetLength(1))
                        {
                            throw new FileLoadException();
                        }

                        var prefIndex = 0;
                        foreach (var item in items)
                        {
                            int parsed;
                            // throws an error if the parsed value is no integer
                            if (int.TryParse(item, out parsed))
                            {
                                // throws an error if the parsed value is not valid
                                if (parsed < 0 || parsed >= array.GetLength(1))
                                {
                                    throw new FileLoadException();
                                }
                                // throws an error if a line has more values than the first line
                                if (prefIndex >= array.GetLength(1))
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
            }

            // throws an error if a line had not enough values for all fields of the array
            foreach (var i in array)
            {
                if (i == -1)
                {
                    throw new FileLoadException();
                }
            }
            return array;
        }
    }
}