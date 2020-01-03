namespace LibToyBot.Spatial
{
    internal class PositionTracker : IPositionTracker
    {
        private int currentX;
        private int currentY;
        private Orientation currentOrientation;
        public bool HasRobotBeenPlaced { get; private set; }

        public void SetPosition(int xCoordinate, int yCoordinate)
        {
            HasRobotBeenPlaced = true;
            currentX = xCoordinate;
            currentY = yCoordinate;
        }


        public (int, int) GetPosition()
        {
            return (currentX, currentY);
        }

        public void SetOrientation(Orientation orientation)
        {
            currentOrientation = orientation;
        }

        public Orientation GetOrientation()
        {
            return currentOrientation;
        }
    }

    public enum Orientation //would prefer this to be internal, but the xUnit test methods require public access
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }

    public enum Direction
    {
        LEFT,
        RIGHT
    }
}
