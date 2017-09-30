using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StableMatcher;

namespace StableMatcherTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GaleShapleyAlgorithmTest
    {
        [TestMethod]
        public void FindStableMatches()
        {
            CollectionAssert.AreEqual(GaleShapleyAlgorithm.FindStableMatches(Examples.Moodle3Men, Examples.Moodle3Women), new []{2, 0, 1});
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FindStableMatches_DifferentDimensions()
        {
            GaleShapleyAlgorithm.FindStableMatches(Examples.Moodle3Men, Examples.Moodle5Women);
        }
    }
}
