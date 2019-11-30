namespace LibToyBot.Outcomes
{
    public interface IOutcome
    {
        OutomeStatus Result { get; set; }
        string Message { get; set; }
    }
}