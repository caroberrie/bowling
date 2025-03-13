namespace bowling.Frames
{
    /// <summary>
    /// Houses the functionality of a frame, this frame can be any number of scores technically. The dictionary could be a list in this case as its an int 
    /// </summary
    public class Frame : IFrame
    {
        private int frameCounter;
        private readonly Dictionary<int, int> frameDictionary;
        private FrameState state;

        public Frame(int frameNumber, Dictionary<int, int> scoreDictionary)
        {
            this.frameCounter = frameNumber;
            this.frameDictionary = scoreDictionary;
            state = FrameState.None;
        }

        public Frame(int frameNumber, Dictionary<int, int> scoreDictionary, FrameState status)
        {
            this.frameCounter = frameNumber;
            this.frameDictionary = scoreDictionary;
            this.state = status;
        }

        public int GetFrameNumber()
        {
            return frameCounter;
        }

        public void setFrameScore(int scoreNum,int value)
        {
            frameDictionary.Add(scoreNum, value);
        }

        public void SetFrameStatus(FrameState state)
        {
            this.state = state;
        }

        public int GetScore(int scoreNum)
        {
            int tempvalue;
            frameDictionary.TryGetValue(scoreNum, out tempvalue);
            return tempvalue;
        }

        public FrameState GetFrameStatus()
        {
            return state;
        }

        public int GetTotalScore()
        {
            return frameDictionary.Values.Sum();
        }
    }
}
