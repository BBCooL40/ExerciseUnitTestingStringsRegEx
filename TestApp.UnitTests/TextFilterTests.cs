using NUnit.Framework;
using System;

namespace TestApp.UnitTests
{
    public class TextFilterTests
    {
        [Test]
        public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
        {
            // Arrange
            var banned = new[] { "cat" };
            var text = "hello world";

            // Act
            var result = TextFilter.Filter(banned, text);

            // Assert
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
        {
            // Arrange
            var banned = new[] { "fox" };
            var text = "The fox jumps over the dog";

            // Act
            var result = TextFilter.Filter(banned, text);

            // Assert
            Assert.That(result, Is.EqualTo("The *** jumps over the dog"));
        }

        [Test]
        public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
        {
            // Arrange
            var banned = Array.Empty<string>();
            var text = "nothing to change";

            // Act
            var result = TextFilter.Filter(banned, text);

            // Assert
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
        {
            // Arrange
            var banned = new[] { "bad word" };
            var text = "this is a bad word indeed";

            // Act
            var result = TextFilter.Filter(banned, text);

            // Assert
            Assert.That(result, Is.EqualTo("this is a ******** indeed"));
        }
    }
}
