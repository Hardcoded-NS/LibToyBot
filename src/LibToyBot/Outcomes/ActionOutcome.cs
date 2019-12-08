namespace LibToyBot.Outcomes
{
    public class ActionOutcome : IOutcome
    {
        public ActionOutcome(OutcomeStatus status, string message = default)
        {
            Result = status;
            Message = message;
        }

        public OutcomeStatus Result { get; set; }
        public string Message { get; set; }
    }
}
