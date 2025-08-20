using NUnit.Framework;
using System.Collections.Generic;
using TestApp; // за MatchUrls

namespace TestApp.UnitTests
{
    public class MatchUrlsTests
    {
        [Test]
        public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
        {
            // Arrange
            string text = "";

            // Act
            var result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
        {
            // Arrange
            string text = "This text has no links at all.";

            // Act
            var result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
        {
            // Arrange
            string text = "Visit https://example.com for details.";
            var expected = new List<string> { "https://example.com" };

            // Act
            var result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
        {
            // Arrange
            string text = "Docs: http://example.org and https://www.google.com/search?q=test";
            var expected = new List<string>
            {
                "http://example.org",
                "https://www.google.com/search?q=test"
            };

            // Act
            var result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
        {
            // Arrange
            string text = "He said: \"https://example.com/path?x=1\" and 'http://www.test.org'.";
            var expected = new List<string>
            {
                "https://example.com/path?x=1",
                "http://www.test.org"
            };

            // Act
            var result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
