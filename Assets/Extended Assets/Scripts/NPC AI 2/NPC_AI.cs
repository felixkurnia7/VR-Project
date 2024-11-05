using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class NPC_AI : MonoBehaviour
{
    [SerializeField]
    private FloatValue timer;
    [SerializeField]
    private NPC npc;
    [SerializeField]
    private float timerThreshold;
    [SerializeField]
    private float eyeContactThreshold;
    BehaviourTree tree;

    private void Awake()
    {
        tree = new BehaviourTree("NPC");
        //tree.AddChild(new Leaf("ActNormal", new ActNormalStrategy(timer, 30)));

        Sequence playActNormal = new Sequence("PlayActNormal", 10);
        playActNormal.AddChild(new Leaf("IsTimerNotPassThreshold", new Condition(() => timer.value < timerThreshold)));
        playActNormal.AddChild(new Leaf("PlayActNormal", new ActionStrategy(() => PlayAnimationNormal())));

        Sequence playActInteresed = new Sequence("PlayActInterested", 0);
        playActInteresed.AddChild(new Leaf("IsEyeContactPassThreshold", new Condition(() => npc.stare > eyeContactThreshold)));
        playActInteresed.AddChild(new Leaf("PlayAnimationIntersted", new ActionStrategy(() => PlayAnimationInterested())));

        //Selector playAllActs = new Selector("PlayAllActs");
        PrioritySelector playAllActs = new PrioritySelector("PlayAllActs");
        playAllActs.AddChild(playActInteresed);
        playAllActs.AddChild(playActNormal);
        
        tree.AddChild(playAllActs);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tree.Process();
    }

    private void PlayAnimationNormal()
    {
        Debug.Log("Play animation Normal");
    }

    private void PlayAnimationInterested()
    {
        Debug.Log("Play animation Interested");
    }
}
