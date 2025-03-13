using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bowling.Bowling;
using bowling.Frames; //why did i name Frame and Frame this made me lose my mind 
using NUnit.Framework;

namespace bowling.UnitTests
{
    [TestOf("GameManager")]
    public class ExampleGameTest
    {
        private IBowlingGame BowlingGame;


        [OneTimeSetUp]
        //test given example
        public void Setup()
        {

            BowlingGame = new BowlingGame();

            BowlingGame.AddFrame(new Frame(0, new Dictionary<int, int>()
            {
                {1, 4 },
                {2, 3 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(1, new Dictionary<int, int>()
            {
                {1, 7 },
                {2, 3 },
            }, FrameState.Spare));
            BowlingGame.AddFrame(new Frame(2, new Dictionary<int, int>()
            {
                {1, 5 },
                {2, 2 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(3, new Dictionary<int, int>()
            {
                {1, 8 },
                {2, 1 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(4, new Dictionary<int, int>()
            {
                {1, 4 },
                {2, 6 },
            }, FrameState.Spare));
            BowlingGame.AddFrame(new Frame(5, new Dictionary<int, int>()
            {
                {1, 2 },
                {2, 4 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(6, new Dictionary<int, int>()
            {
                {1, 8 },
                {2, 0 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(7, new Dictionary<int, int>()
            {
                {1, 8 },
                {2, 0 },
            }, FrameState.None));
            BowlingGame.AddFrame(new Frame(8, new Dictionary<int, int>()
            {
                {1, 8 },
                {2, 2 },
            }, FrameState.Spare));
            BowlingGame.AddFrame(new Frame(9, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 1 },
                {3, 7 }
            }, FrameState.Strike));


        }

        [Test]
        [TestCase(ExpectedResult = 110)]
        public int CheckFinalScore()
        {
            return BowlingGame.GetScore();  
        }
    }

    [TestOf("GameManager")]
    public class PerfectGameTest
    {
        private IBowlingGame BowlingGame;


        [OneTimeSetUp]
        //test perfect game
        public void Setup()
        {

            BowlingGame = new BowlingGame();

            BowlingGame.AddFrame(new Frame(0, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(1, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(2, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(3, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(4, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(5, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(6, new Dictionary<int, int>()
            {
                {1, 10},
                {2, 0},
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(7, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(8, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(9, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 10 },
                {3, 10 }
            }, FrameState.Strike));


        }

        [Test]
        [TestCase(ExpectedResult = 300)]
        public int CheckFinalScore()
        {
            return BowlingGame.GetScore();
        }
    }

    public class RandomGameTest
    {
        private IBowlingGame BowlingGame;


        [OneTimeSetUp]
        //test perfect game
        public void Setup()
        {

            BowlingGame = new BowlingGame();

            BowlingGame.AddFrame(new Frame(0, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(1, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(2, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(3, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(4, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(5, new Dictionary<int, int>()
            {
                {1, 10 },
                {2, 0 },
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(6, new Dictionary<int, int>()
            {
                {1, 10},
                {2, 0},
            }, FrameState.Strike));
            BowlingGame.AddFrame(new Frame(7, new Dictionary<int, int>()
            {
                {1, 8 },
                {2, 2 },
            }, FrameState.Spare));
            BowlingGame.AddFrame(new Frame(8, new Dictionary<int, int>()
            {
                {1, 9 },
                {2, 1 },
            }, FrameState.Spare));
            BowlingGame.AddFrame(new Frame(9, new Dictionary<int, int>()
            {
                {1, 9 },
                {2, 1 },
                {3, 9 }
            }, FrameState.Spare));


        }

        [Test]
        [TestCase(ExpectedResult = 255)]
        public int CheckFinalScore()
        {
            return BowlingGame.GetScore();
        }
    }
}
