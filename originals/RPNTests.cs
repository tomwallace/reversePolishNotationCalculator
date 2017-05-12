 public class RPNTests
    {
        [Theory]
        [InlineData("3 4 +", 7)]
        [InlineData("-2 -2 *", 4)]
        [InlineData("2 3 ^", 8)]
        [InlineData("-8 -4 -", -4)]
        [InlineData("5 9 -", -4)]
        [InlineData("2 4 ^", 16)]
        [InlineData("12 2 /", 6)]
        [InlineData("4 5 7 2 + - *", -16)]
        [InlineData("3 4 + 2  * 7 / ", 2)]
        [InlineData("5 7 + 6 2 -  *  ", 48)]
        [InlineData("4 2 3 5 1 - + * +", 18)]
        public void Calculation_IsCorrect(string command, double expected)
        {
            var actual = new RPN(command).Get();            

            Assert.Equal(expected, actual);
        }
    }