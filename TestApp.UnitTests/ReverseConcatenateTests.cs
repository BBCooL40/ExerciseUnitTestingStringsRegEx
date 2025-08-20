using NUnit.Framework;
using System;
using System.Linq;
using TestApp; // за да достъпим ReverseConcatenate

namespace TestApp.UnitTests
{
    public class ReverseConcatenateTests
    {
        [Test]
        public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string[] input = Array.Empty<string>();

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
        {
            // Arrange
            string[] input = { "hello" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
        {
            // Arrange
            string[] input = { "one", "two", "three" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo("threetwoone"));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
        {
            // Arrange
            string[]? input = null;

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
        {
            // Arrange
            string[] input = { "  ", "\t", "a" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            // Редът се обръща: {"  ", "\t", "a"} -> "a\t  "
            Assert.That(result, Is.EqualTo("a\t  "));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
        {
            // Arrange
            // Масив от 1000 елемента: "x0", "x1", ..., "x999"
            var input = Enumerable.Range(0, 1000).Select(i => $"x{i}").ToArray();
            var expected = string.Concat(input.Reverse());

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
