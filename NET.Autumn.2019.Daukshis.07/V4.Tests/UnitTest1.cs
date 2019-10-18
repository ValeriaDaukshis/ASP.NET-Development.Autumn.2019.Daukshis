using Algorithms.V4.GcdImplementations;
using Algorithms.V4.Interfaces;
using Moq;
using NUnit.Framework;

namespace V4.Tests
{
    [TestFixture]
    public class Tests
    {
        private ILogger _logger;
        private IStopWatcher _stopWatcher;
        private IAlgorithm _algorithm;

        [SetUp]
        public void Setup()
        {
            _logger = Mock.Of<ILogger>();
            _stopWatcher = Mock.Of<IStopWatcher>();
            _algorithm = Mock.Of<IAlgorithm>();
        }

        [Test]
        public void CalculateDecorator_WithTwoParamsAndStopWatcherAndLogger()
        {
            var gcd = new EuclideanAlgorithmDecorator(_algorithm, _logger, _stopWatcher);
            gcd.Calculate(1, 3);
            Mock<IAlgorithm> mockAlgorithm = Mock.Get(_algorithm);
            mockAlgorithm.Verify(
                a => a.Calculate(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

            Mock<IStopWatcher> mockStopWatcher = new Mock<IStopWatcher>(_stopWatcher);
            mockStopWatcher.Verify(a => a.Start());
            mockStopWatcher.Verify(a => a.Stop());
        }
    }
}