namespace LibToyBot
{
    internal class PositionTracker : IPositionTracker
    {

        private int currentX;
        private int currentY;
        private Orientation currentOrientation;

        public void SetPosition(int xCoordinate, int yCoordinate)
        {
            currentX = xCoordinate;
            currentY = yCoordinate;
            //TODO: track history?
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
        North,
        South,
        East,
        West
    }
}
