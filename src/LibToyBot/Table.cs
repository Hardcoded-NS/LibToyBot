using LibToyBot.Exceptions;

namespace LibToyBot
{
    public class Table
    {
        public int HorizontalAxis { get; }
        public int VerticalAxis { get; }

        /// <summary>
        ///  Creates a table of 5x5
        ///  Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        public Table()
        {
            VerticalAxis = HorizontalAxis = 5;
        }

        /// <summary>
        /// <para>
        ///  Initializes a new instance of the <see cref="Table"/> class.
        /// </para>
        /// <para>
        ///  A table is a grid bounded by the specified X &amp; Y axis maxima.
        ///  The X and Y axis should both be positive values greater than zero
        ///  Negative axis are not valid.
        ///
        ///  Not for public consumption; this is a placeholder for future versions that allow for user-designated table-sizes
        /// </para>
        /// </summary>
        /// <param name="xAxis">The size of the x axis</param>
        /// <param name="yAxis">The size of the y axis</param>
        /// <exception cref="InvalidTableRangeException"></exception>
        internal Table(int xAxis, int yAxis)
        {
            HorizontalAxis = xAxis;
            VerticalAxis = yAxis;
            
            // Validate that the x & y maxima form a bounded grid
            if (!IsSceneValid(xAxis, yAxis))
            {
                throw new InvalidTableRangeException(
                    $"Scene axes do not form a bounded grid. X Axis: {xAxis} , Y Axis: {yAxis}");
            }

        }

        private static bool IsSceneValid(int xAxis, int yAxis)
        {
            // both x & y axis maxima should be positive and greater than zero
            return xAxis > 0 && yAxis > 0;
        }
    }
}
