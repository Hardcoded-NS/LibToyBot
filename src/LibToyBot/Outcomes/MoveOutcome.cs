namespace LibToyBot.Outcomes
{
    public class MoveOutcome : IOutcome
    {
        public MoveOutcome(OutomeStatus status, string moveResult)
        {
            Result = status;
            Message = moveResult;
        }

        public OutomeStatus Result { get; set; }
        public string Message { get; set; }

    }
}
