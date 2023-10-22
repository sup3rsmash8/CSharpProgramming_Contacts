using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void ContactService_GetContact_Should_WhenExpressionIsNull_ReturnNull()
        {
            // Arrange
            IContactService contactService = new ContactService();

            // Act
            IContactUser contact = contactService.GetContact(null!)!;

            // Assert
            Assert.Null(contact);
        }
    }
}