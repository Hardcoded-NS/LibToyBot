using LibToyBot.Outcomes;

namespace LibToyBot.Reporting
{
    public class ReportOutcome : IOutcome
    {
        public ReportOutcome(OutcomeStatus result, string message, PositionReport positionReport)
        {
            Result = result;
            Message = message;
            PositionReport = positionReport;
        }

        public OutcomeStatus Result { get; }
        public string Message { get;  }
        public PositionReport PositionReport { get;  }
    }
}
