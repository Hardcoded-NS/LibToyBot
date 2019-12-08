using System.Collections;
using System.Collections.Generic;

namespace LibToyBot.Test.TestData
{
    public class MovementProcessorSuccessTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 0, Orientation.NORTH };
            yield return new object[] { 0, 1, Orientation.NORTH };
            yield return new object[] { 0, 2, Orientation.NORTH };
            yield return new object[] { 0, 3, Orientation.NORTH };
            yield return new object[] { 0, 4, Orientation.NORTH };
            yield return new object[] { 1, 0, Orientation.NORTH };
            yield return new object[] { 1, 1, Orientation.NORTH };
            yield return new object[] { 1, 2, Orientation.NORTH };
            yield return new object[] { 1, 3, Orientation.NORTH };
            yield return new object[] { 1, 4, Orientation.NORTH };
            yield return new object[] { 2, 0, Orientation.NORTH };
            yield return new object[] { 2, 1, Orientation.NORTH };
            yield return new object[] { 2, 2, Orientation.NORTH };
            yield return new object[] { 2, 3, Orientation.NORTH };
            yield return new object[] { 2, 4, Orientation.NORTH };
            yield return new object[] { 3, 0, Orientation.NORTH };
            yield return new object[] { 3, 1, Orientation.NORTH };
            yield return new object[] { 3, 2, Orientation.NORTH };
            yield return new object[] { 3, 3, Orientation.NORTH };
            yield return new object[] { 3, 4, Orientation.NORTH };
            yield return new object[] { 4, 0, Orientation.NORTH };
            yield return new object[] { 4, 1, Orientation.NORTH };
            yield return new object[] { 4, 2, Orientation.NORTH };
            yield return new object[] { 4, 3, Orientation.NORTH };
            yield return new object[] { 4, 4, Orientation.NORTH };
            yield return new object[] { 5, 4, Orientation.NORTH };
            yield return new object[] { 5, 0, Orientation.NORTH };
            yield return new object[] { 5, 1, Orientation.NORTH };
            yield return new object[] { 5, 2, Orientation.NORTH };
            yield return new object[] { 5, 3, Orientation.NORTH };
            yield return new object[] { 5, 4, Orientation.NORTH };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
