namespace LibToyBot
{
    internal interface IBoundsEvaluator
    {
        /// <summary>
        ///   <para>
        ///     Validates that the specified x &amp; y position are within the bounds of the table's horizontal and vertical axis.
        ///     Tennis rules apply; on the line is in.
        ///   </para>
        /// </summary>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <returns></returns>
        bool InBounds(in int xPosition, in int yPosition);
    }
}