namespace GroupAndComponent
{
    public class Component
    {
        public bool Valid { get; set; } = true;

        public Group Root { get; } = null;

        /// <summary>
        /// Creates a new singleton Component with the given root.
        /// </summary>
        /// <param name="root">The root of the component.</param>
        public Component(Group root)
        {
            Root = root;
        }
    }
}