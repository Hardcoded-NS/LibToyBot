namespace LibToyBot.Outcomes
{
    public interface IOutcome
    {
        OutcomeStatus Result { get;  }
        string Message { get; }
    }
}