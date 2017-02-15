using System;

namespace InUit.Model.Periods
{
    public class PeriodException : Exception
    {
        public PeriodException(string periodString)
            : base($"Period string '{periodString}' is malformed.") {
        }

        public PeriodException(string periodString, Exception innerException)
            : base($"Period string '{periodString}' is malformed.", innerException) {
        }
    }
}
