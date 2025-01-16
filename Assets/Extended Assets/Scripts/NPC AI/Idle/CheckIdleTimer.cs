using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIdleTimer : Node
{
    private FloatValue _timer;
    private NPC_AI _npc;

    public CheckIdleTimer(FloatValue timer, Transform transform)
    {
        _timer = timer;
        _npc = transform.GetComponent<NPC_AI>();
    }

    public override NodeState Evaluate()
    {
        if (_timer.value > 120f)
        {
            Debug.Log("timer value > 120f");
            _npc.notIdle = true;
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            Debug.Log("timer value < 120f");
            state = NodeState.FAILURE;
            return state;
        }

        //state = NodeState.FAILURE;
        //return state;
    }
}
