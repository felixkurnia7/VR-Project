using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayInterestedAnim : Node
{
    private Animator anim;

    public PlayInterestedAnim(Transform transform)
    {
        anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        anim.SetBool("interested", true);
        anim.SetBool("idle", false);
        anim.SetBool("bored", false);

        state = NodeState.SUCCESS;
        return state;

        //state = NodeState.FAILURE;
        //return state;
    }
}
