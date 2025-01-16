using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBoredTimer : Node
{
    private FloatValue _timer;

    public CheckBoredTimer(FloatValue timer)
    {
        _timer = timer;
    }

    public override NodeState Evaluate()
    {
        if (_timer.value >= 300f && _timer.value < 600f)
        {
            Debug.Log("CheckBoredTimer");
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
