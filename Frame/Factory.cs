namespace bowling.Frame
{
    public class Factory
    {
        public static IFrame CreateFrame(int FrameCount, List<int> FrameScores)
        {
            FrameState state;
            if (FrameScores[0] == 10)
            {
                state = FrameState.Strike;
            }
            else if (FrameScores[0] + FrameScores[1] == 10)
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
                    {1, FrameScores[0] },
                    {2, FrameScores[1] },
                    {3 ,FrameScores[2] },
                    { 4 ,FrameScores[3] },
                    { 5 ,FrameScores[4] }
                }, state);
            }
            else
            {
                return new Frame(FrameCount, new Dictionary<int, int>()
                {
                    {1, FrameScores[0] },
                    {2, FrameScores[1] }
                }, state);
            }
        }
    }
}
