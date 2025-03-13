
namespace bowling.Frames
{
    public interface IFrame
    {
        int GetFrameNumber();

        int GetScore(int scoreFrame);

        int GetTotalScore();

        void setFrameScore(int scoreFrame, int scoreValue);

        void SetFrameStatus(FrameState status);

        FrameState GetFrameStatus();
    }
}
