using System.Collections.Generic;
using LibToyBot.Outcomes;

namespace LibToyBot
{
    /// <summary>Handle all movement intents, including bounds checking and position tracking</summary>
    internal class MovementProcessor
    {
        private readonly IBoundsEvaluator _boundsEvaluator;
        private readonly IPositionTracker _positionTracker;
        private readonly Dictionary<Orientation, (int xModifier, int yModifier)> movementMap;

        public MovementProcessor(IBoundsEvaluator boundsEvaluator, IPositionTracker positionTracker)
        {
            _boundsEvaluator = boundsEvaluator;
            _positionTracker = positionTracker;

            movementMap = new Dictionary<Orientation, (int xModifier, int yModifier)>
            {
                {Orientation.North, (0, 1)},
                {Orientation.South, (0, -1)},
                {Orientation.East, (1, 0)},
                {Orientation.West, (-1, 0)}
            };
        }

        /// <summary>
        /// <para>
        ///     Attempts to move the robot forward one place, based on the current position and orientation of the robot
        /// </para>
        /// </summary>
        public MoveOutcome Move()
        {
            // get the current position
            (int xCurrent, int yCurrent) = _positionTracker.GetPosition();

            // get the current orientation
            var orientation = _positionTracker.GetOrientation();
            
            // derive projected new position if the robot was allowed to move
            (int projectedX, int projectedY) = EvaluateMove(xCurrent, yCurrent, orientation);

            // determine if projected position is still in bounds
            if (!_boundsEvaluator.InBounds(projectedX, projectedY)) // projected move is out of bounds
                return new MoveOutcome(OutomeStatus.Fail, $"The new position {projectedX}, {projectedY} would make the robot fall off the table");
            
            // in bounds, so perform the move
            _positionTracker.SetPosition(projectedX, projectedY); 
            return new MoveOutcome(OutomeStatus.Success, "The robot has moved");
        }

        private (int, int) EvaluateMove(int x, int y, Orientation orientation)
        {
            var (xModifier, yModifier) = movementMap[orientation];
            return (x + xModifier, y + yModifier);
        }
    }
}
