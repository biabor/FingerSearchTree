using Nodes;

namespace GroupAndComponent
{
    public class Component
    {
        public bool Valid { get; set; } = true;

        public Node Root { get; } = null;

        /// <summary>
        /// Creates a new singleton Component with the given root.
        /// </summary>
        /// <param name="root">The root of the component.</param>
        public Component(Node root)
        {
            Root = root;
        }
    }
}