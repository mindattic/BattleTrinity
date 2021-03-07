using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTrinity
{

    public enum TURN_STATE
    {
        TurnStart = 0,
        SelectTarget = 1, ChooseDirection = 2, MeasureDistance = 3,
        Resolve = 99,
        TurnEnd = 100
    }


    public enum CAMERA_STATE
    {
        Scroll = 0,
        Follow = 1   
    }


    public enum ACTOR_MOVE_STATE
    {
        Idle = 0,
        Moving = 1,
        BullRush = 2
    }

    public enum CURSOR_STATE
    {
        Pointer = 0,
        Move = 1
    }


}
