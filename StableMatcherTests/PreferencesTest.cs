using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StableMatcher;

namespace StableMatcherTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PreferencesTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetPreferences_FileNotFound()
        {
            Preferences.GetPreferencesFromFile("../../preferences/nonexistent_preferences.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_CharsInArray()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_with_chars.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_ValueTooHigh()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_value_too_high.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_ValueTooLow()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_value_too_low.txt");
        }

        [TestMethod]
        public void GetPreferences_Success()
        {
            var correctArray = new[,] {{1, 0, 2}, {2, 1, 0}, {0, 2, 1}};
            var result = Preferences.GetPreferencesFromFile("../../preferences/preferences.txt");
            CollectionAssert.AreEqual(correctArray, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_WrongArraySize()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_wrong_array_size.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_WrongArraySize2()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_wrong_array_size_2.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void GetPreferences_WrongArraySize3()
        {
            Preferences.GetPreferencesFromFile("../../preferences/preferences_wrong_array_size_3.txt");
        }
    }
}
