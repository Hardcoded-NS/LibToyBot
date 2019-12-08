namespace LibToyBot
{
    public interface IPositionReporter
    {
        PositionReport Report();
    }

    internal class PositionReporter : IPositionReporter
    {
        private readonly IPositionTracker _positionTracker;

        public PositionReporter(IPositionTracker positionTracker)
        {
            _positionTracker = positionTracker;
        }

        public PositionReport Report()
        {
            var position = _positionTracker.GetPosition();
            return new PositionReport
            {
                Orientation = _positionTracker.GetOrientation(),
                PositionX = position.xPosition,
                PositionY = position.yPosition
            };
        }
    }
}
