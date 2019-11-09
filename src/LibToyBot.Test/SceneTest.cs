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

        [Fact] //TODO: Add a theory with a wider range of axis variation
        public void TestSceneProperties()
        {
            const int axis = 5;
            var fiveByFiveScene = new Scene(axis, axis);

            fiveByFiveScene.HorizontalAxis.ShouldBe(axis);
            fiveByFiveScene.VerticalAxis.ShouldBe(axis);
        }

    }
}
