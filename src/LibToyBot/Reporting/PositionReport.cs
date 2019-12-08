namespace LibToyBot.Reporting
{
    public class PositionReport
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Orientation Orientation { get; set; }
        public override string ToString() => $"{PositionX},{PositionY},{Orientation}";
    }
}
