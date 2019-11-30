namespace LibToyBot
{
    internal interface IPositionTracker
    {
        void SetPosition(int xCoordinate, int yCoordinate);
        (int, int) GetPosition();
        void SetOrientation(Orientation orientation);
        Orientation GetOrientation();
    }
}