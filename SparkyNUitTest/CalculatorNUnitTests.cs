using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int result = cal.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calc = new();    

            //Act
            bool isOdd = calc.IsOddNumber(10);

            //Assert
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(15)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(a);

            //Assert
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            return calc.IsOddNumber(a);

        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.96
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator cal = new();

            //Act
            double result = cal.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, 0.2);
            // 15.7 - 16.1
        }

        [Test]
        public void OddRanger_InputMInAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator cal = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5 - 10

            //Act
            List<int> result = cal.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.AreEqual(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
