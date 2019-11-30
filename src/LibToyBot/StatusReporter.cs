namespace LibToyBot
{
    internal class StatusReporter
    {
        private readonly IPositionTracker _positionTracker;

        public StatusReporter(IPositionTracker positionTracker)
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
