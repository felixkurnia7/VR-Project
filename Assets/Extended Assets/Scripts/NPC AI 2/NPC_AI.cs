using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class NPC_AI : MonoBehaviour
{
    [SerializeField] HeadLookAtPlayer head;

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

    //[SerializeField]
    //private bool isNormal;

    private Animator anim;
    BehaviourTree tree;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tree = new BehaviourTree("NPC");

        PrioritySelector actions = new("NPC Logic");

        // All Sequences
        Sequence interestedSequence = new("InterestedSequence", 5);
        Sequence excitedSequence = new("ExcitedSequence", 10);
        Sequence boredSequence = new("BoredSequence", 20);
        Sequence confuseSequence = new("ConfuseSequence", 15);

        // Check Statuses
        bool CheckTimeInterested()
        {
            if (timer.value > timeInterestedThreshold)
            {
                return true;
            }
            interestedSequence.Reset();
            return false;
        }

        bool CheckWPMInterested()
        {
            if (wpm.value > wpmInterestedThreshold)
                return true;
            interestedSequence.Reset();
            return false;
        }

        bool CheckEyeContactInterested()
        {
            if (npc.stare > stareInterestedThreshold)
                return true;
            interestedSequence.Reset();
            return false;
        }

        bool CheckTimeExcited()
        {
            if (timer.value > timeExcitedThreshold)
                return true;
            excitedSequence.Reset();
            return false;
        }

        bool CheckWPMExcited()
        {
            if (wpm.value > wpmExcitedThreshold)
                return true;
            excitedSequence.Reset();
            return false;
        }

        bool CheckHandExcited()
        {
            if ((leftHand.value + rightHand.value) > handExcitedThreshold)
                return true;
            excitedSequence.Reset();
            return false;
        }

        bool CheckEyeContactExcited()
        {
            if (npc.eyeContactDone == isStareDone)
                return true;
            excitedSequence.Reset();
            return false;
        }

        bool CheckTimeBored()
        {
            if (timer.value > timeBoredThreshold)
            {
                return true;
            }
            boredSequence.Reset();
            return false;
        }

        bool CheckTimeConfuse()
        {
            if (timer.value > timeConfuseThreshold)
                return true;
            confuseSequence.Reset();
            return false;
        }

        bool CheckWPMConfuse()
        {
            if (wpm.value < wpmConfuseThreshold)
                return true;
            confuseSequence.Reset();
            return false;
        }

        bool CheckVolumeConfuse()
        {
            if (volume.value < volumeConfuseThreshold)
                return true;
            confuseSequence.Reset();
            return false;
        }

        bool CheckEyeContactConfuse()
        {
            if (npc.stare < stareConfuseThreshold)
                return true;
            confuseSequence.Reset();
            return false;
        }

        // Sequence Interested
        interestedSequence.AddChild(new Leaf("IsPassTimeInterested?", new Condition(CheckTimeInterested)));
        interestedSequence.AddChild(new Leaf("IsPassWPMInterested?", new Condition(CheckWPMInterested)));
        interestedSequence.AddChild(new Leaf("IsPassEyeContactInterested?", new Condition(CheckEyeContactInterested)));
        interestedSequence.AddChild(new Leaf("PlayAnimationInterested", new PlayAnimationNPC(anim, head, false, true)));
        actions.AddChild(interestedSequence);
        // -----------------------------------------------------------

        // Sequence Excited
        excitedSequence.AddChild(new Leaf("IsPassTimeExcited?", new Condition(CheckTimeExcited)));
        excitedSequence.AddChild(new Leaf("IsPassWPMExcited?", new Condition(CheckWPMExcited)));
        excitedSequence.AddChild(new Leaf("IsPassHandExcited?", new Condition(CheckHandExcited)));
        excitedSequence.AddChild(new Leaf("IsEyeContactDone?", new Condition(CheckEyeContactExcited)));
        excitedSequence.AddChild(new Leaf("PlayAnimationExcited", new PlayAnimationNPC(anim, head, false, false, true)));
        actions.AddChild(excitedSequence);
        // -------------------------------------------------------------

        // Sequence Bored
        boredSequence.AddChild(new Leaf("IsPassTimeBored?", new Condition(CheckTimeBored)));
        boredSequence.AddChild(new Leaf("PlayAnimationBored", new PlayAnimationNPC(anim, head, false, false, false, true)));
        actions.AddChild(boredSequence);
        // -------------------------------------------------------------

        // Sequence Confuse
        confuseSequence.AddChild(new Leaf("IsPassTimeConfuse?", new Condition(CheckTimeConfuse)));
        confuseSequence.AddChild(new Leaf("IsPassWPMConfuse?", new Condition(CheckWPMConfuse)));
        confuseSequence.AddChild(new Leaf("IsPassVolumeConfuse?", new Condition(CheckVolumeConfuse)));
        confuseSequence.AddChild(new Leaf("IsPassEyeContactConfuse?", new Condition(CheckEyeContactConfuse)));
        confuseSequence.AddChild(new Leaf("PlayAnimationConfuse", new PlayAnimationNPC(anim, head, false, false, false, false, true)));
        actions.AddChild(confuseSequence);
        // -------------------------------------------------------------

        // Play idle animation
        Leaf playNormal = new("PlayAnimationNormal", new PlayAnimationNPC(anim, head, true));
        actions.AddChild(playNormal);

        tree.AddChild(actions);
    }

    // Update is called once per frame
    void Update()
    {
        tree.Process();
    }
}
