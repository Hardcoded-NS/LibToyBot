namespace LibToyBot
{
    public interface IOutcome
    {
        bool Success { get; set; }
        string Result { get; set; }
    }
}