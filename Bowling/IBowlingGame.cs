using bowling.Frame;

namespace bowling.Bowling
{
    public interface IBowlingGame
    {
        void AddFrame(IFrame Currentframe);

        void IncrementFrame();

        GameState getCurrentGameState();
    }
}
