namespace LibToyBot.Outcomes
{
    public interface IOutcome
    {
        OutcomeStatus Result { get; set; }
        string Message { get; set; }
    }
}