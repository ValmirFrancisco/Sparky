using Xunit;

namespace Sparky
{
    public class CalculatorXUnitFacts
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int result = cal.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calc = new();    

            //Act
            bool isOdd = calc.IsOddNumber(10);

            //Assert
            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(15)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(a);

            //Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            //Arrange
            Calculator calc = new();

            //Act
            var result = calc.IsOddNumber(a);

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(5.4, 10.5)] //15.9
        [InlineData(5.43, 10.53)] //15.96
        [InlineData(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator cal = new();

            //Act
            double result = cal.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 0.2);
            // 15.7 - 16.1
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator cal = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5 - 10

            //Act
            List<int> result = cal.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);

            Assert.Contains(7, result);

            Assert.NotEmpty(result);

            Assert.Equal(3, result.Count);

            Assert.DoesNotContain(6, result);

            Assert.Equal(result.OrderBy(u=>u),result);

            //Assert.That(result, Is.Unique);
        }
    }
}
