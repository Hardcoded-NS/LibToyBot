using LibToyBot.Spatial;

namespace LibToyBot.Reporting
{
    internal class PositionReporter : IPositionReporter
    {
        private readonly IPositionTracker _positionTracker;

        public PositionReporter(IPositionTracker positionTracker)
        {
            _positionTracker = positionTracker;
        }

        /// <summary>
        /// Reports on the position of the robot. If the Robot has not yet been placed, then the PositionReport property <tt>HasRobotBeenPlaced</tt> will be <tt>false</tt>
        /// </summary>
        /// <returns></returns>
        public PositionReport Report()
        {
            var (positionX, positionY) = _positionTracker.GetPosition();

            if (!_positionTracker.HasRobotBeenPlaced) 
                return new PositionReport();

            return new PositionReport
            {
                Orientation = _positionTracker.GetOrientation(),
                PositionX = positionX,
                PositionY = positionY,
                HasRobotBeenPlaced = _positionTracker.HasRobotBeenPlaced
            };
        }
    }
}
