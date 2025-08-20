using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class SubstringTests
    {
        [Test]
        public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
        {
            // Arrange
            string toRemove = "fox";
            string input = "The quick brown fox jumps over the lazy dog";

            // Act
            string result = Substring.RemoveOccurrences(toRemove, input);

            // Assert
            Assert.That(result, Is.EqualTo("The quick brown jumps over the lazy dog"));
        }

        [Test]
        public void Test_RemoveOccurrences_RemovesSubstringFromStart()
        {
            // Arrange
            string toRemove = "fox";
            string input = "FoX jumps high"; // умишлено различен case

            // Act
            string result = Substring.RemoveOccurrences(toRemove, input);

            // Assert
            Assert.That(result, Is.EqualTo("jumps high"));
        }

        [Test]
        public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
        {
            // Arrange
            string toRemove = "fox";
            string input = "see the red FOX"; // умишлено различен case

            // Act
            string result = Substring.RemoveOccurrences(toRemove, input);

            // Assert
            Assert.That(result, Is.EqualTo("see the red"));
        }

        [Test]
        public void Test_RemoveOccurrences_RemovesAllOccurrences()
        {
            // Arrange
            string toRemove = "cat";
            string input = "Cat  cat   cAt"; // много срещания + различен case + множество интервали

            // Act
            string result = Substring.RemoveOccurrences(toRemove, input);

            // Assert
            // всички "cat" се махат, интервалите се колапсват, Trim чисти краищата → празен низ
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
