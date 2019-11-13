using LibToyBot.Exceptions;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class TableTest
    {
        [Fact]
        public void TestTableConstructor()
        {
            var defaultTable = new Table();
            defaultTable.ShouldNotBeNull();
        }

        [Fact]
        public void TestTableProperties()
        {
            const int axis = 5;
            var fiveByFiveTable = new Table(axis, axis);

            fiveByFiveTable.HorizontalAxis.ShouldBe(axis);
            fiveByFiveTable.VerticalAxis.ShouldBe(axis);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void TestValidTableDimensions(int xAxis, int yAxis)
        {
            Should.NotThrow(() => {
                new Table(xAxis, yAxis);
            });
        }


        [Theory]
        [InlineData(1, -1)]
        [InlineData(-2, 5)]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(-1, -1)]
        public void TestInvalidTableDimensions(int xAxis, int yAxis)
        {
            Should.Throw<InvalidTableRangeException>(() => {
                new Table(xAxis, yAxis);
            });
        }

    }
}
