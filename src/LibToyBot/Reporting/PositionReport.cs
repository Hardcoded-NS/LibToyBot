using LibToyBot.Spatial;

namespace LibToyBot.Reporting
{
    public class PositionReport
    {
        public bool HasRobotBeenPlaced;
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public Orientation? Orientation { get; set; }
        public override string ToString() => HasRobotBeenPlaced 
            ? $"{PositionX},{PositionY},{Orientation}" 
            : "The robot has not been placed on the table";
    }
}
