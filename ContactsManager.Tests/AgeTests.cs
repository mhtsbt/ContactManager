using ContactsManager.Controllers;
using System;
using Xunit;

namespace ContactsManager.Tests
{
    public class AgeTests
    {
        [Fact]
        public void GetAge_WhenProvidingValidDate_ReturnCorrectAge()
        {
            var controller = new ContactPersonController(null);

            var testResult = controller.CalculateAge(new DateTime(1990, 5, 15));

            Assert.Equal(testResult, 27);

        }
    }
}