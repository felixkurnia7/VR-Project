using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class TaskNormal : Node
{
    private readonly NPC _npc;
    private readonly StringValue _text;
    private readonly FloatValue _timer;
    private readonly FloatValue _volume;
    private readonly FloatValue _wpm;

    // Batas value animasi Normal
    private readonly float _eyeContactThreshold;
    private readonly float _textThreshold;
    private readonly float _timerThreshold;
    private readonly float _volumeThreshold;
    private readonly float _wpmThreshold;

    public TaskNormal(NPC npc, StringValue text, FloatValue timer, FloatValue volume, FloatValue wpm)
    {
        _npc = npc;
        _text = text;
        _timer = timer;
        _volume = volume;
        _wpm = wpm;
    }

    public override NodeState Evaluate()
    {
        // Jalanin animasi Duduk Nomral

        state = NodeState.RUNNING;
        return state;
    }
}
