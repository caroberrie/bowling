namespace bowling.Frames
{
    public class Factory
    {
        public static IFrame CreateFrame(int FrameCount, List<int> FrameScores, int FramesToPlay, int PinstoPlay)
        {
            FrameState state;
            if (FrameScores[0] == PinstoPlay)
            {
                state = FrameState.Strike;
            }
            else if (FrameScores[0] + FrameScores[1] == PinstoPlay)
            {
                state = FrameState.Spare;
            }
            else
            {
                state = FrameState.None;
            }

            if (FrameCount == FramesToPlay)
            {
                return new Frame(FrameCount, new Dictionary<int, int>()
                {
                    {1, FrameScores[0] },
                    {2, FrameScores[1] },
                    {3 ,FrameScores[2] },
                    
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
