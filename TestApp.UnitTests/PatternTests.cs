using NUnit.Framework;
using System;            // за ArgumentException
using TestApp;           // за Pattern

namespace TestApp.UnitTests
{
    public class PatternTests
    {
        // Валидни входове
        [TestCase("Abc", 1, "aBc")]
        [TestCase("Abc", 3, "aBcaBcaBc")]
        [TestCase("a1-b!", 2, "a1-B!a1-B!")]
        [TestCase("A B", 1, "a b")]
        public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(
            string input, int repetitionFactor, string expected)
        {
            // Act
            string result = Pattern.GeneratePatternedString(input, repetitionFactor);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
        {
            // Act + Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("", 1));
        }

        [Test]
        public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
        {
            // Act + Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("Abc", -1));
        }

        [Test]
        public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
        {
            // Act + Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString("Abc", 0));
        }
    }
}
