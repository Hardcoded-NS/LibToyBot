namespace LibToyBot.Outcomes
{
    public class ReportOutcome : IOutcome //TODO: evaluate the need for this interface
    {
        public OutcomeStatus Result { get; set; }
        public string Message { get; set; }
        public PositionReport PositionReport { get; set; }
    }
}
