using NUnit.Framework;

namespace MathFunctions.Tests
{
    public class MathFunctionsTests
    {
        [TestCase("({}<>)", ExpectedResult = true)]
        [TestCase("<{>}", ExpectedResult = false)]
        [TestCase("{{}}", ExpectedResult = true)]
        [TestCase("((()<>))", ExpectedResult = true)]
        [TestCase("(((){<{}}>))", ExpectedResult = false)]
        [TestCase("((", ExpectedResult = false)]
        [TestCase("(a+(b+(a+b)-<c/d>-k))", ExpectedResult = true)]
        public bool CheckBrackets_ExpectedTrueIfBracketsHaveCorrectPositions(string scopes)
            => Task2.MathFunctions.CheckBrackets(scopes);
    }
}