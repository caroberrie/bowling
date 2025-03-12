namespace bowling.Frame
{
    public class Factory
    {
        public static IFrame CreateFrame(int FrameCount, int score1, int score2, int? score3 = null)
        {
            FrameState state;
            if (score1 == 10)
            {
                state = FrameState.Strike;
            }
            else if (score1 + score2 == 10)
            {
                state = FrameState.Spare;
            }
            else
            {
                state = FrameState.None;
            }
            if( FrameCount == 9)
            {
                return new Frame(FrameCount, new Dictionary<int, int>()
                {
                    {1, score1 },
                    {2, score2 },
                    {3 ,score3.Value}
                }, state);
            }
            else
            {
                return new Frame(FrameCount, new Dictionary<int, int>()
                {
                    {1, score1 },
                    {2, score2 }
                }, state);
            }
        }
    }
}
