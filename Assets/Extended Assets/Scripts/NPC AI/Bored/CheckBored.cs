using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBored : Node
{
    private NPC_AI _npc;

    public CheckBored(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }

    public override NodeState Evaluate()
    {
        if (_npc.notBored == true)
        {
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
