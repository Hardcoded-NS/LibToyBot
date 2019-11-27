using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class BoundsEvaluatorTest
    {
        private readonly BoundsEvaluator boundsEvaluator;
        public BoundsEvaluatorTest()
        {
            boundsEvaluator = new BoundsEvaluator(new Table());
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        public void TestInBounds(int xPosition, int yPosition)
        {
            bool result = boundsEvaluator.InBounds(xPosition, yPosition);
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 3)]
        [InlineData(6, 4)]
        [InlineData(3, -2)]
        [InlineData(0, 0)]
        [InlineData(0, int.MinValue)]
        [InlineData(0, int.MaxValue)]
        public void TestOutOfBounds(int xPosition, int yPosition)
        {
            bool result = boundsEvaluator.InBounds(xPosition, yPosition);
            result.ShouldBeFalse();
        }
    }
}
