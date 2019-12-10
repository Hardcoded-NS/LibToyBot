using LibToyBot.Spatial;

namespace LibToyBot
{
    public interface IPositionTracker
    {
        void SetPosition(int xCoordinate, int yCoordinate);
        (int xPosition, int yPosition) GetPosition();
        void SetOrientation(Orientation orientation);
        Orientation GetOrientation();
    }
}