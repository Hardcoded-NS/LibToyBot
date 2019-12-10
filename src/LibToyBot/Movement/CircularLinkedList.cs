using LibToyBot.Spatial;

namespace LibToyBot.Movement
{
    internal class CircularLinkedList
    {

        public Facing First { get; set; }
        public Facing Last { get; set; }

        public void Add(Orientation orientation)
        {
            // if the list is empty, then create the new node as the first (and only) node
            if (First == null)
            {
                First = new Facing(orientation);
                Last = First;
                First.Next = Last;
                First.Previous = Last;
            }
            else // list had an item, append a new item to the list
            {
                var newNode = new Facing(orientation);
                Last.Next = newNode;
                newNode.Next = First;
                newNode.Previous = Last;
                Last = newNode;
                First.Previous = Last;
            }
        }

        public Facing Get(Orientation orientation)
        {
            // starting at the First node, find the node with a value of Orientation
            return First.Value == orientation ? First : Get(orientation, First.Next);
        }

        private Facing Get(Orientation orientation, Facing node)
        {
            return node.Value == orientation ? node : Get(orientation, node.Next);
        }

    }

    internal class Facing
    {
        public Facing(Orientation value)
        {
            Value = value;
        }

        public Orientation Value { get; }
        public Facing Previous { get; set; }
        public Facing Next { get; set; }
    }

}
