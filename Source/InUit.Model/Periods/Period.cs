using System;

namespace InUit.Model.Periods
{
    public class Period
    {
        public string Code => $"{Year.ToString("0000")}{Month.ToString("00")}";
        public string Name => $"{Month.ToString("00")}/{Year.ToString("0000")}";
        public int Month { get; set; }
        public int Year { get; set; }

        public Period() 
            : this (DateTimeOffset.Now.DateTime) {
        }
        public Period(DateTime dateTime)
            : this(dateTime.Month, dateTime.Year) {
        }
        public Period(int month, int year) {            
            if (month < 1 || month > 12) {
                throw new ArgumentOutOfRangeException("month", $"Given month '{month.ToString("00")}' is out of range.");
            }            

            Month = month;
            Year = year;
        }
        public Period(string periodString) {
            if(String.IsNullOrEmpty(periodString) || String.IsNullOrWhiteSpace(periodString)) {
                throw new ArgumentNullException(nameof(periodString));
            }
            if(periodString.Length != 6) {
                throw new PeriodException(periodString);
            }

            try {
                var year = Int32.Parse(periodString.Substring(0, 4));
                var month = Int32.Parse(periodString.Substring(4, 2));

                if(month < 1 || month > 12) {
                    throw new ArgumentOutOfRangeException("month", $"Given month '{month.ToString("00")}' is out of range.");
                }

                Year = year;
                Month = month;
            } catch(Exception ex) {
                throw new PeriodException(periodString, ex);
            }
        }
    }
}
