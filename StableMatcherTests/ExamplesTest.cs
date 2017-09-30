using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StableMatcher;

namespace StableMatcherTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ExamplesTest
    {
        [TestMethod]
        public void ExampleTest()
        {
            CollectionAssert.AreEqual(Examples.Moodle3Men, new[,] { { 1, 0, 2 }, { 2, 1, 0 }, { 0, 2, 1 } });
        }
    }
}
