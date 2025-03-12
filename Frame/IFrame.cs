using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowling.Frame
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
