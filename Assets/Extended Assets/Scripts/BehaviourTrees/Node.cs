using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehaviourTrees
{
    // UntilSuccess
    //// Repeat

    public class PrioritySelector : Selector
    {
        List<Node> sortedChildren;
        List<Node> SortedChildren => sortedChildren ??= SortChildren();

        protected virtual List<Node> SortChildren() => children.OrderByDescending(child => child.priority).ToList();

        public PrioritySelector(string name, int priority = 0) : base(name, priority) { }

        public override void Reset()
        {
            base.Reset();
            sortedChildren = null;
        }

        public override Status Process()
        {
            foreach (var child in SortedChildren)
            {
                switch (child.Process())
                {
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        Reset();
                        return Status.Success;
                    default:
                        continue;
                }
            }

            Reset();
            return Status.Failure;
        }
    }

    public class Selector : Node
    {
        public Selector(string name, int priority = 0) : base(name, priority) { }

        public override Status Process()
        {
            if (currentChild < children.Count)
            {
                switch (children[currentChild].Process())
                {
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        Reset();
                        return Status.Success;
                    default:
                        currentChild++;
                        return Status.Running;
                }
            }

            Reset();
            return Status.Failure;
        }
    }

    public class Sequence : Node
    {
        public Sequence(string name, int priority = 0) : base(name, priority) { }

        public override Status Process()
        {
            if (currentChild < children.Count)
            {
                switch (children[currentChild].Process())
                {
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        currentChild = 0;
                        return Status.Failure;
                    default:
                        currentChild++;
                        return currentChild == children.Count ? Status.Success : Status.Running;
                }
            }

            Reset();
            return Status.Success;
        }
    }

    public class BehaviourTree : Node
    {
        public BehaviourTree(string name) : base(name) { }

        public override Status Process()
        {
            while (currentChild < children.Count)
            {
                var status = children[currentChild].Process();
                if (status != Status.Success)
                {
                    return status;
                }
                currentChild++;
            }
            return Status.Success;
        }
    }

    public class Leaf : Node
    {
        readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy, int priority = 0) : base(name, priority)
        {
            // Preconditions.CheckNotNull(strategy);
            Preconditions.CheckNotNull(strategy);
            this.strategy = strategy;
        }

        public override Status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
    }

    public class Node
    {
        public enum Status { Success, Failure, Running }

        public readonly string name;
        public readonly int priority;

        public readonly List<Node> children = new();
        protected int currentChild;

        public Node(string name = "Node", int priority = 0)
        {
            this.name = name;
            this.priority = priority;
        }

        public void AddChild(Node child) => children.Add(child);

        public virtual Status Process() => children[currentChild].Process();

        public virtual void Reset()
        {
            currentChild = 0;
            foreach (var child in children)
            {
                child.Reset();
            }
        }
    }

    //public class BehaviourTree : Node
    //{
    //    readonly IPolicy policy;

    //    public BehaviourTree(string name, IPolicy policy = null) : base(name)
    //    {
    //        this.policy = policy ?? Policies.RunForever;
    //    }

    //    public override Status Process()
    //    {
    //        Status status = children[currentChild].Process();
    //        if (policy.ShouldReturn(status))
    //        {
    //            return status;
    //        }

    //        currentChild = (currentChild + 1) % children.Count;
    //        return Status.Running;
    //    }

    //    public void PrintTree()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        PrintNode(this, 0, sb);
    //        Debug.Log(sb.ToString());
    //    }

    //    static void PrintNode(Node node, int indentLevel, StringBuilder sb)
    //    {
    //        sb.Append(' ', indentLevel * 2).AppendLine(node.name);
    //        foreach (Node child in node.children)
    //        {
    //            PrintNode(child, indentLevel + 1, sb);
    //        }
    //    }
    //}
}