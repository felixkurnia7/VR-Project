using System.Collections.Generic;
using BehaviorTree;

public class NPC_AI : Tree
{
    public NPC npc;
    public StringValue text;
    public FloatValue timer;
    public FloatValue volume;
    public FloatValue wpm;

    public bool notIdle = false;
    public bool notInterested = false;
    public bool notBored = false;

    protected override Node SetupTree()
    {
        Node root = new Sequence(new List<Node>
        {
            new Selector(new List<Node>
            {
                new CheckIdle(transform),

                new Sequence(new List<Node>
                {
                    new PlayIdleAnim(transform),

                    new CheckIdleTimer(timer, transform)
                })
            })
            //new Selector(new List<Node>
            //{
            //    new CheckIdle(transform),

            //    new Sequence(new List<Node>
            //    {
            //        new CheckIdleTimer(timer),
            //        new SetNPCToIdle(transform),
            //        new PlayIdleAnim(transform)
            //    })
            //}),

            //new Selector(new List<Node>
            //{
            //    new CheckInterested(transform),

            //    new Sequence(new List<Node>
            //    {
            //        new CheckInterestedTimer(timer),
            //        new SetNPCToInterested(transform),
            //        new PlayInterestedAnim(transform)
            //    })
            //}),

            //new Selector(new List<Node>
            //{
            //    new CheckBored(transform),

            //    new Sequence(new List<Node>
            //    {
            //        new CheckBoredTimer(timer),
            //        new SetNPCToBored(transform),
            //        new PlayBoredAnimation(transform)
            //    })
            //}),

            //new Sequence(new List<Node>
            //{
            //    new CheckTimerValue(timer),
            //    new TaskNormal(npc, text, timer, volume, wpm, transform),

            //}),
            //new Sequence(new List<Node>
            //{
            //    new CheckEnemyInAttackRange(transform),
            //    new TaskAttack(transform),
            //}),
            //new Sequence(new List<Node>
            //{
            //    new CheckEnemyInFOVRange(transform),
            //    new TaskGoToTarget(transform),
            //}),
            //new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
