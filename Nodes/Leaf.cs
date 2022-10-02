using GroupAndComponent;
using Blocks;

namespace Nodes
{
    public class Leaf : Node
    {
        public int Value { get; set; } = int.MinValue;

        public override int Min { get => Value; }

        public override int Max { get => Value; }

        public Leaf()
        {
            new Node(new Block2(new Block1(this)));
            Father.OldNode = FatherNode;
            Father.Father.Group = FatherNode.Group;
        }

        public Leaf(int value)
        {
            Value = value;
        }

        internal override bool ContainsValue(int value)
        {
            return value == Value;
        }
    }
}
