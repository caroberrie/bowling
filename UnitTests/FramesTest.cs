using bowling.Frames;
using NUnit.Framework;

namespace UnitTesting
{
    namespace BowlingTests.FrameTests
    {
        [TestOf("Frame")]
        public class FrameTests
        {
            private Frame frame;
            [SetUp]
            public void Setup()
            {
                frame = new Frame(1, new Dictionary<int, int>()
                {
                    [1] = 7,
                    [2] = 3
                }
             );
            }

            [Test]
            [TestCase(ExpectedResult = FrameState.None)]
            public FrameState TestFrameStatus()
            {
                return frame.GetFrameStatus();
            }

            [Test]
            [TestCase(ExpectedResult = 1)]
            public int TestFrameNumber()
            {
                return frame.GetFrameNumber();
            }

            [Test]
            [TestCase(ExpectedResult = 7)]
            public int TestScore()
            {
                return frame.GetScore(1);
            }

            [Test]
            [TestCase(ExpectedResult = 10)]
            public int TestTotalScore()
            {
                return frame.GetTotalScore();
            }
        }
    }
}
