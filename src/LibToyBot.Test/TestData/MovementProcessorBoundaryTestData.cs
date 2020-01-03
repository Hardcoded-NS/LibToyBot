using System.Collections;
using System.Collections.Generic;
using LibToyBot.Spatial;

namespace LibToyBot.Test.TestData
{
    public class MovementProcessorBoundaryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Left edge
            yield return new object[] { 0, 0, Orientation.WEST };
            yield return new object[] { 0, 1, Orientation.WEST };
            yield return new object[] { 0, 2, Orientation.WEST };
            yield return new object[] { 0, 3, Orientation.WEST };
            yield return new object[] { 0, 4, Orientation.WEST };

            // top edge
            yield return new object[] { 0, 4, Orientation.NORTH };
            yield return new object[] { 1, 4, Orientation.NORTH };
            yield return new object[] { 2, 4, Orientation.NORTH };
            yield return new object[] { 3, 4, Orientation.NORTH };
            yield return new object[] { 4, 4, Orientation.NORTH };

            //right edge
            yield return new object[] { 4, 0, Orientation.EAST };
            yield return new object[] { 4, 1, Orientation.EAST };
            yield return new object[] { 4, 2, Orientation.EAST };
            yield return new object[] { 4, 3, Orientation.EAST };
            yield return new object[] { 4, 4, Orientation.EAST };

            //bottom edge
            yield return new object[] { 0, 0, Orientation.SOUTH };
            yield return new object[] { 1, 0, Orientation.SOUTH };
            yield return new object[] { 2, 0, Orientation.SOUTH };
            yield return new object[] { 3, 0, Orientation.SOUTH };
            yield return new object[] { 4, 0, Orientation.SOUTH };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
