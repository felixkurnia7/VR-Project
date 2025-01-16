using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInterestedTimer : Node
{
    private FloatValue _timer;

    public CheckInterestedTimer(FloatValue timer)
    {
        _timer = timer;
    }

    public override NodeState Evaluate()
    {
        if (_timer.value < 300f && _timer.value >= 120f)
        {
            Debug.Log("CheckInterestedTimer");
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
