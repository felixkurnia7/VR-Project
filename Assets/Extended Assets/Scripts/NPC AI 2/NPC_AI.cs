using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class NPC_AI : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] FloatValue wpm;
    [SerializeField] FloatValue volume;
    [SerializeField] FloatValue timer;
    [SerializeField] Hand leftHand;
    [SerializeField] Hand rightHand;
    [SerializeField] NPC npc;

    [Header("Interested Value Threshold")]
    [SerializeField] float timeInterestedThreshold;
    [SerializeField] float wpmInterestedThreshold;
    [SerializeField] float stareInterestedThreshold;

    [Header("Excited Value Threshold")]
    [SerializeField] float timeExcitedThreshold;
    [SerializeField] float wpmExcitedThreshold;
    [SerializeField] bool isStareDone;
    [SerializeField] float handExcitedThreshold;

    [Header("Bored Value Threshold")]
    [SerializeField] float timeBoredThreshold;

    [Header("Confuse Value Threshold")]
    [SerializeField] float timeConfuseThreshold;
    [SerializeField] float wpmConfuseThreshold;
    [SerializeField] float stareConfuseThreshold;
    [SerializeField] float volumeConfuseThreshold;

    [SerializeField]
    private bool isNormal;

    readonly private Animator anim;
    BehaviourTree tree;

    // Start is called before the first frame update
    void Start()
    {
        tree = new BehaviourTree("NPC");

        PrioritySelector actions = new("NPC Logic");

        // Sequence Interested
        Sequence playInterestedAnimSeq = new("PlayInterestedAnimSeq", 5);
        bool IsPassTimeThreshold()
        {
            if (timer.value > timeInterestedThreshold)
            {
                return true;
            }
            playInterestedAnimSeq.Reset();
            return false;
        }

        playInterestedAnimSeq.AddChild(new Leaf("IsNotPassTimeThreshold?", new Condition(IsPassTimeThreshold)));
        playInterestedAnimSeq.AddChild(new Leaf("PlayAnimationInterested", new PlayAnimationNPC(anim, false, true)));
        actions.AddChild(playInterestedAnimSeq);
        // -----------------------------------------------------------

        // Sequence Bored
        Sequence playBoredSeq = new("PlayBoredSeq", 10);
        bool IsBored()
        {
            if (timer.value > timeBoredThreshold)
            {
                return true;
            }
            playBoredSeq.Reset();
            return false;
        }
        
        playBoredSeq.AddChild(new Leaf("IsBored", new Condition(IsBored)));
        playBoredSeq.AddChild(new Leaf("PlayAnimationBored", new PlayAnimationNPC(anim, false, false, true)));
        actions.AddChild(playBoredSeq);
        // -------------------------------------------------------------

        // Play idle animation
        Leaf playNormal = new("PlayAnimationNormal", new PlayAnimationNPC(anim, true, false));

        actions.AddChild(playNormal);
        

        //Sequence playActNormal = new Sequence("PlayActNormal", 10);
        //playActNormal.AddChild(new Leaf("IsTimerNotPassThreshold", new Condition(() => timer.value < timerThreshold)));
        //playActNormal.AddChild(new Leaf("PlayActNormal", new ActionStrategy(() => PlayAnimationNormal())));

        //Sequence playActInteresed = new Sequence("PlayActInterested", 0);
        //playActInteresed.AddChild(new Leaf("IsEyeContactPassThreshold", new Condition(() => npc.stare > eyeContactThreshold)));
        //playActInteresed.AddChild(new Leaf("PlayAnimationIntersted", new ActionStrategy(() => PlayAnimationInterested())));

        ////Selector playAllActs = new Selector("PlayAllActs");
        //PrioritySelector playAllActs = new PrioritySelector("PlayAllActs");
        //playAllActs.AddChild(playActInteresed);
        //playAllActs.AddChild(playActNormal);

        tree.AddChild(actions);
    }

    // Update is called once per frame
    void Update()
    {
        tree.Process();
    }
}
