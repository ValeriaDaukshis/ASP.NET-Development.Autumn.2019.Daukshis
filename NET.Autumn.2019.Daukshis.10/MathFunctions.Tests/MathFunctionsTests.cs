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
        public bool CheckBrackets_ExpectedTrueIfBracketsHaveCorrectPositions(string scopes)
            => Task2.MathFunctions.CheckBrackets(scopes);
    }
}