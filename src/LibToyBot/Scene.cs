using System;

namespace LibToyBot
{
    public class Scene
    {
        public int HorizontalAxis { get; }
        public int VerticalAxis { get; }

        public Scene()
        {

        }

        public Scene(int xAxis, int yAxis)
        {
            HorizontalAxis = xAxis;
            VerticalAxis = yAxis;
        }
    }
}
