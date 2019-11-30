using System.Collections;
using System.Collections.Generic;

namespace LibToyBot.Test.TestData
{
    public class MovementProcessorBoundaryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Left edge
            yield return new object[] { 0, 0, Orientation.West };
            yield return new object[] { 0, 1, Orientation.West };
            yield return new object[] { 0, 2, Orientation.West };
            yield return new object[] { 0, 3, Orientation.West };
            yield return new object[] { 0, 4, Orientation.West };
            yield return new object[] { 0, 5, Orientation.West };

            // top edge
            yield return new object[] { 0, 5, Orientation.North };
            yield return new object[] { 1, 5, Orientation.North };
            yield return new object[] { 2, 5, Orientation.North };
            yield return new object[] { 3, 5, Orientation.North };
            yield return new object[] { 4, 5, Orientation.North };
            yield return new object[] { 5, 5, Orientation.North };

            //right edge
            yield return new object[] { 5, 0, Orientation.East };
            yield return new object[] { 5, 1, Orientation.East };
            yield return new object[] { 5, 2, Orientation.East };
            yield return new object[] { 5, 3, Orientation.East };
            yield return new object[] { 5, 4, Orientation.East };
            yield return new object[] { 5, 5, Orientation.East };

            //bottom edge
            yield return new object[] { 0, 0, Orientation.South };
            yield return new object[] { 1, 0, Orientation.South };
            yield return new object[] { 2, 0, Orientation.South };
            yield return new object[] { 3, 0, Orientation.South };
            yield return new object[] { 4, 0, Orientation.South };
            yield return new object[] { 5, 0, Orientation.South };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
