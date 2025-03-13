using bowling.Frames;

namespace bowling.Bowling
{
    public interface IBowlingGame
    {
        void AddFrame(IFrame Currentframe);

        void IncrementFrame();

        int GetScore();

        GameState getCurrentGameState();
    }
}
