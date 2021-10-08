using System;
using Xunit;

namespace Calculator.Tests
{
    public class SimpleCalculatorProgramShould
    {

        // Testing the division method for dividing with Zero

        [Fact]
        public void DivideByZeroShouldEqualInfinity()
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float restul = sut.Division(10, 0);
            Assert.Equal(float.PositiveInfinity, restul);

        }
        // Testing the division method for some cases
        [Theory]
        [InlineData(8,40, 5)]
        [InlineData(0,0,5)]
        [InlineData(-10,-100,10)]
        [InlineData(1.5,6,4)]
        public void DivideTwoNumbersShouldEqualRight(float expected , float num1 , float num2) 
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float restul= sut.Division(num1, num2);
            Assert.Equal(expected, restul);
        }

        // Testing the Multiplication method for some cases
        [Theory]
        [InlineData(40, 8, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-100, -10, 10)]
        [InlineData(6,1.5, 4)]
        public void MultiplyTwoNumbersShouldEqualRight(float expected, float num1, float num2)
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float restul = sut.Multiplication(num1, num2);
            Assert.Equal(expected, restul);
        }

        // Testing the Addition method that takes two values for some cases
        [Theory]
        [InlineData(63, 58, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-50, -75, 25)]
        public void AddTwoNumbersShouldEqualRight(float expected, float num1, float num2)
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float restul = sut.Addition(num1, num2);
            Assert.Equal(expected, restul);
        }

        // Testing the Addition method that takes an array of numbers
        [Fact]
        public void AddManyNumbersShouldEqualRight()
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float[] arrayOfNumbers = { 1, 63, 5, 8, -9 };
            float restul = sut.Addition(arrayOfNumbers);
            Assert.Equal(68, restul);

        }

        // Testing the Subtraction method that takes two values for some cases
        [Theory]
        [InlineData(53, 58, 5)]
        [InlineData(-7, 7, 14)]
        [InlineData(0, 50, 50)]
        public void SubtractTwoNumbersShouldEqualRight(float expected, float num1, float num2)
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float restul = sut.Subtraction(num1, num2);
            Assert.Equal(expected, restul);
        }

        // Testing the Subtraction method that takes an array of numbers
        [Fact]
        public void SubtractManyNumbersShouldEqualRight()
        {
            SimpleCalculatorProgram sut = new SimpleCalculatorProgram();
            float[] arrayOfNumbers = { 120, 33, 7, 0, -19 };
            float restul = sut.Subtraction(arrayOfNumbers);
            Assert.Equal(99, restul);

        }

        /*Testing an input if it's a valid number(up till float) or not. If not,
         * testing won't not complete because of the ValidNumber method is a recursive one,
         * this could be solved by refactor the method by doing a loop until the user enter 
         * a valid input and make it retur a boolean for instance.*/
        [Fact]
        public void ValidNumberShouldReturnOnlyNumber()
        {
            // if TryParse fail the testing process will stuck in a loop waiting the user to enter a new input
            // and won't continue
            string num = "10";
            Assert.IsType<float>(Calculator.SimpleCalculatorProgram.ValidNumber(num));

        }


    }
}
