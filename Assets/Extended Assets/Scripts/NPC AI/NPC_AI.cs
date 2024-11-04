using System.Collections.Generic;
using BehaviorTree;

public class NPC_AI : Tree
{
    public static NPC npc;
    public static StringValue text;
    public static FloatValue timer;
    public static FloatValue volume;
    public static FloatValue wpm;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new TaskNormal(npc, text, timer, volume, wpm),
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
