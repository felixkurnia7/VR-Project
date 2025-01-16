using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PlayBoredAnimation : Node
{
    private Animator _anim;

    public PlayBoredAnimation(Transform transform)
    {
        _anim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        _anim.SetBool("bored", true);
        _anim.SetBool("idle", false);
        _anim.SetBool("interested", false);

        state = NodeState.SUCCESS;
        return state;
    }
}
