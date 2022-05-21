using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        public Customer customer;
        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            // Customer customer = new Customer();

            //Act
            string fullName = customer.GreetAndCombineNames("Araribóia", "Clayderman");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(fullName, "Hello, Araribóia Clayderman");
                Assert.That(fullName, Is.EqualTo("Hello, Araribóia Clayderman"));
                Assert.That(fullName, Does.Contain(","));
                Assert.That(fullName, Does.StartWith("Hello,"));
                Assert.That(fullName, Does.EndWith("Clayderman"));
                Assert.That(fullName, Does.Contain("Araribóia clayderman").IgnoreCase);
                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+"));
            });

        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange
            // Customer customer = new Customer();

            // Act
            // string fullName = customer.GreetAndCombineNames("Araribóia", "Clayderman");
             
            //Assert
            Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
       {
            //Arrange
            int result = customer.Discount;

            //Act

            //Assert
            Assert.That(result, Is.InRange(10, 25));

        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            //Arrange
            customer.GreetAndCombineNames("Asdrubal", "");

            //Act

            //Assert
            Assert.IsNotNull(customer.GreetMessage);

            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            //Arrange
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Moncorvo"));

            //Act

            //Assert
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineNames("", "Moncorvo"),
                            Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            //Arrange
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Moncorvo"));

            //Assert
            Assert.That(() => customer.GreetAndCombineNames("", "Moncorvo"),
                            Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLess100Than100Order_ReturnBasicCustomer()
        {
            //Arrange
            customer.OrderTotal = 10;

            //Act
            var result = customer.GetCustomerDetails();

            //Assert
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMore100Than100Order_ReturnPlatinumCustomer()
        {
            //Arrange
            customer.OrderTotal = 110;

            //Act
            var result = customer.GetCustomerDetails();

            //Assert
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
