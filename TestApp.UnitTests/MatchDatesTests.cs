using NUnit.Framework;
using System;       // за ArgumentException
using TestApp;      // за MatchDates

namespace TestApp.UnitTests
{
    public class MatchDatesTests
    {
        [Test]
        public void Test_Match_ValidDate_ReturnsExpectedResult()
        {
            // Arrange
            string input = "Some text 31/Dec/2022 here";
            string expected = "Day: 31, Month: Dec, Year: 2022";

            // Act
            string result = MatchDates.Match(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_NoMatch_ReturnsEmptyString()
        {
            // Arrange
            string input = "Invalid date format";
            string expected = string.Empty;

            // Act
            string result = MatchDates.Match(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_MultipleMatches_ReturnsFirstMatch()
        {
            // Arrange
            string input = "13/Jul/1928, 10-Nov-1934, 01/Jan/1951";
            string expected = "Day: 13, Month: Jul, Year: 1928";

            // Act
            string result = MatchDates.Match(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = string.Empty;

            // Act
            string result = MatchDates.Match(input);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_Match_NullInput_ThrowsArgumentException()
        {
            // Act + Assert
            Assert.Throws<ArgumentException>(() => MatchDates.Match(null));
        }
    }
}
