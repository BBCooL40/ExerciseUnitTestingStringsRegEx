using NUnit.Framework;
using TestApp; // за EmailValidator

namespace TestApp.UnitTests
{
    public class EmailValidatorTests
    {
        // Валидни имейли според зададения regex
        [TestCase("test@example.com")]
        [TestCase("user.name+tag@gmail.com")]
        [TestCase("a_b-c%+1@sub.domain.co")]
        [TestCase("NAME.SURNAME@EXAMPLE.ORG")]
        public void Test_ValidEmails_ReturnsTrue(string email)
        {
            // Act
            bool result = EmailValidator.IsValidEmail(email);

            // Assert
            Assert.That(result, Is.True);
        }

        // Невалидни имейли за този regex
        [TestCase("user@domain")]            // липсва TLD
        [TestCase("user@.com")]              // невалиден домейн
        [TestCase("user@@domain.com")]       // двойно '@'
        [TestCase("user@domain.c")]          // TLD < 2 знака
        [TestCase("user@domain.123")]        // TLD не е само букви
        [TestCase("user name@domain.com")]   // интервал в локалната част
        public void Test_InvalidEmails_ReturnsFalse(string email)
        {
            // Act
            bool result = EmailValidator.IsValidEmail(email);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
