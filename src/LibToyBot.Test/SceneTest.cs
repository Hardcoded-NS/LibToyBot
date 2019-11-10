using LibToyBot.Exceptions;
using Shouldly;
using Xunit;

namespace LibToyBot.Test
{
    public class SceneTest
    {
        [Fact]
        public void TestSceneConstructor()
        {
            var emptyScene = new Scene();
            emptyScene.ShouldNotBeNull();
        }

        [Fact]
        public void TestSceneProperties()
        {
            const int axis = 5;
            var fiveByFiveScene = new Scene(axis, axis);

            fiveByFiveScene.HorizontalAxis.ShouldBe(axis);
            fiveByFiveScene.VerticalAxis.ShouldBe(axis);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void TestValidSceneDimensions(int xAxis, int yAxis)
        {
            Should.NotThrow(() => {
                new Scene(xAxis, yAxis);
            });
        }


        [Theory]
        [InlineData(1, -1)]
        [InlineData(-2, 5)]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(-1, -1)]
        public void TestInvalidSceneDimensions(int xAxis, int yAxis)
        {
            Should.Throw<InvalidSceneRangeException>(() => {
                new Scene(xAxis, yAxis);
            });
        }

    }
}
