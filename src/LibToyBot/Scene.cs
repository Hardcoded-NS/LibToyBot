using System;
using LibToyBot.Exceptions;

namespace LibToyBot
{
    public class Scene
    {
        public int HorizontalAxis { get; }
        public int VerticalAxis { get; }

        /// <summary>
        ///  Internal constructor. Not for general consumption.
        ///  Initializes a new instance of the <see cref="Scene"/> class.
        /// </summary>
        internal Scene()
        {
            VerticalAxis = HorizontalAxis = 5;
        }

        /// <summary>
        /// <para>
        ///  Initializes a new instance of the <see cref="Scene"/> class.
        /// </para>
        /// <para>
        ///  A Scene is a grid bounded by the specified X &amp; Y axis maxima.
        ///  The X and Y axis should exist in the same plane; that is, if X is positive, then Y should also be positive.
        ///  Negative axis are valid.
        /// </para>
        /// </summary>
        /// <param name="xAxis">The size of the x axis</param>
        /// <param name="yAxis">The size of the y axis</param>
        /// <exception cref="InvalidSceneRangeException"></exception>
        public Scene(int xAxis, int yAxis)
        {
            HorizontalAxis = xAxis;
            VerticalAxis = yAxis;
            
            // Validate that the x & y maxima form a bounded grid
            if (!IsSceneValid(xAxis, yAxis))
            {
                throw new InvalidSceneRangeException(
                    $"Scene axes do not form a bounded grid. X Axis: {xAxis} , Y Axis: {yAxis}");
            }

        }

        private static bool IsSceneValid(int xAxis, int yAxis)
        {
            // if x is positive, then y should also be positive
            // if x is negative, then y should also be negative
            return xAxis > 0 && yAxis > 0 || // both x & y are positive
                   xAxis < 0 && yAxis < 0; // both x & y are negative
        }
    }
}
