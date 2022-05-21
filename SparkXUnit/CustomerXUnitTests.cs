using Xunit;

namespace Sparky
{
    public class CustomerXUnitFacts
    {
        public Customer customer;

        public CustomerXUnitFacts()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            // Customer customer = new Customer();

            //Act
            customer.GreetAndCombineNames("Araribóia", "Clayderman");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Equal("Hello, Araribóia Clayderman", customer.GreetMessage);
                Assert.Contains(",", customer.GreetMessage);
                Assert.StartsWith("Hello,", customer.GreetMessage);
                Assert.EndsWith("Clayderman", customer.GreetMessage);
                Assert.Contains("Araribóia clayderman", customer.GreetMessage, StringComparison.CurrentCultureIgnoreCase);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+", customer.GreetMessage);
            });

        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange
            // Customer customer = new Customer();

            // Act
            // string fullName = customer.GreetAndCombineNames("Araribóia", "Clayderman");

            //Assert
            Assert.Null(customer.GreetMessage);

        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Arrange
            int result = customer.Discount;

            //Act

            //Assert
            Assert.InRange(result, 10, 25);

        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            //Arrange
            customer.GreetAndCombineNames("Asdrubal", "");

            //Act

            //Assert
            Assert.NotNull(customer.GreetMessage);

            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            //Arrange
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Moncorvo"));

            //Act

            //Assert
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            //Arrange
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Moncorvo"));

        }

        [Fact]
        public void CustomerType_CreateCustomerWithLess100Than100Order_ReturnBasicCustomer()
        {
            //Arrange
            customer.OrderTotal = 10;

            //Act
            var result = customer.GetCustomerDetails();

            //Assert
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMore100Than100Order_ReturnPlatinumCustomer()
        {
            //Arrange
            customer.OrderTotal = 110;

            //Act
            var result = customer.GetCustomerDetails();

            //Assert
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
