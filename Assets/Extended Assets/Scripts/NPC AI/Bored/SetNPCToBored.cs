using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class SetNPCToBored : Node
{
    private NPC_AI _npc;

    public SetNPCToBored(Transform transform)
    {
        _npc = transform.GetComponent<NPC_AI>();
    }

    public override NodeState Evaluate()
    {
        _npc.notBored = true;
        _npc.notIdle = false;
        _npc.notInterested = false;

        state = NodeState.RUNNING;
        return state;
    }
}
