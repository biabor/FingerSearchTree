using GroupAndComponent;
using Blocks;

namespace Nodes
{
    public class Leaf : Node
    {
        public int Value { get; set; } = int.MinValue;

        public override int Min { get => Value; }

        public override int Max { get => Value; }

        /// <summary>
        /// Create the Leaf of the initial tree.
        /// </summary>
        public Leaf()
        {
            new Node(new Block2(new Block1(this)));
        }

        /// <summary>
        /// Creates a new empty Leaf, with the given value, not connected to anything.
        /// </summary>
        /// <param name="value">the value of the leaf.</param>
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
