using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bowling.Bowling;

namespace Bowling.Frames { }
public enum FrameState { None, Spare, Strike, ThirdFrameSpare, ThirdFrameStrike }

public static class FrameStateUtil
{
    public static bool GetValidStateName(FrameState state)
    {
        return state switch
        {
            FrameState.None => true,
            FrameState.Spare => true,
            FrameState.Strike => true,
            _ => false,
        };
    }


}