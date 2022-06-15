using GroupAndComponent;
using Blocks;

namespace Nodes
{
    public class Leaf : Node
    {
        public int Value { get; set; } = int.MinValue;

        /// <summary>
        /// Create the Leaf of the initial tree.
        /// </summary>
        public Leaf()
        {
            new Node(new Block2(new Block1(this)));
            Group = new Group(this);
        }

        /// <summary>
        /// Creates a new empty Leaf, with the given value, not connected to anything.
        /// </summary>
        /// <param name="value">the value of the leaf.</param>
        public Leaf(int value)
        {
            Value = value;
            Group = new Group(this);
        }

    }
}
