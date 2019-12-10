using System;
using System.Collections.Generic;
using LibToyBot.Outcomes;
using LibToyBot.Spatial;

namespace LibToyBot.Movement
{
    /// <summary>Handle all movement intents, including bounds checking and position tracking</summary>
    internal class MovementProcessor : IMovementProcessor
    {
        private readonly IBoundsEvaluator _boundsEvaluator;
        private readonly IPositionTracker _positionTracker;
        private readonly Dictionary<Orientation, (int xModifier, int yModifier)> movementMap;
        private readonly CircularLinkedList directionList = new CircularLinkedList();

        public MovementProcessor(IBoundsEvaluator boundsEvaluator, IPositionTracker positionTracker)
        {
            _boundsEvaluator = boundsEvaluator;
            _positionTracker = positionTracker;

            movementMap = new Dictionary<Orientation, (int xModifier, int yModifier)>
            {
                {Orientation.NORTH, (0, 1)},
                {Orientation.SOUTH, (0, -1)},
                {Orientation.EAST, (1, 0)},
                {Orientation.WEST, (-1, 0)}
            };

            directionList.Add(Orientation.NORTH);
            directionList.Add(Orientation.EAST);
            directionList.Add(Orientation.SOUTH);
            directionList.Add(Orientation.WEST);
        }

        /// <summary>
        /// <para>
        ///     Attempts to move the robot forward one place, based on the current position and orientation of the robot
        /// </para>
        /// </summary>
        public ActionOutcome Move()
        {
            // get the current position
            (int xCurrent, int yCurrent) = _positionTracker.GetPosition();

            // get the current orientation
            var orientation = _positionTracker.GetOrientation();
            
            // derive projected new position if the robot was allowed to move
            (int projectedX, int projectedY) = EvaluateMove(xCurrent, yCurrent, orientation);

            // determine if projected position is still in bounds
            if (!_boundsEvaluator.InBounds(projectedX, projectedY)) // projected move is out of bounds
                return new ActionOutcome(OutcomeStatus.Fail, $"The new position {projectedX}, {projectedY} would make the robot fall off the table");
            
            // in bounds, so perform the move
            _positionTracker.SetPosition(projectedX, projectedY); 
            return new ActionOutcome(OutcomeStatus.Success, $"The robot has moved to position {projectedX}, {projectedY}");
        }

        public ActionOutcome Turn(Direction direction)
        {
            var orientation = _positionTracker.GetOrientation();
            switch(direction)
            {
                case Direction.LEFT:
                    break;
                case Direction.RIGHT:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            var facing = directionList.Get(orientation);
            var newOrientation = direction switch
            {
                Direction.LEFT => facing.Previous.Value,
                Direction.RIGHT => facing.Next.Value
            };
            _positionTracker.SetOrientation(newOrientation);
            return new ActionOutcome(OutcomeStatus.Success);
        }

        public ActionOutcome Place(in int xPosition, in int yPosition, Orientation orientation)
        {
            // determine if projected position is still in bounds
            if (!_boundsEvaluator.InBounds(xPosition, yPosition)) // projected move is out of bounds
                return new ActionOutcome(OutcomeStatus.Fail, $"The position {xPosition}, {yPosition} would place the robot off the table");

            // in bounds, so perform the move
            _positionTracker.SetPosition(xPosition, yPosition);
            return new ActionOutcome(OutcomeStatus.Success, $"The robot has been placed at {xPosition}, {yPosition}, facing {orientation}");
        }

        private (int, int) EvaluateMove(int x, int y, Orientation orientation)
        {
            var (xModifier, yModifier) = movementMap[orientation];
            return (x + xModifier, y + yModifier);
        }
    }

}
