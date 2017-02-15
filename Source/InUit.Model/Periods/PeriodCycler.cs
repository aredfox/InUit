using Kf.Core.Range;
using System;

namespace InUit.Model.Periods
{
    public class PeriodCycler
    {
        private IRange<int> _months;        

        public Period Current { get; private set; }
        public Period Next() {
            Current = MoveMonth(1);
            return Current;
        }
        public Period Previous() {
            Current = MoveMonth(-1);
            return Current;
        }
        private Period MoveMonth(int amount) {            
            var newMonth = Current.Month + amount;
            var newYear = Current.Year;

            if (!_months.IsInRange(newMonth)) {
                if(amount < 0) {
                    newMonth = _months.Maximum;
                    newYear -= 1;
                } else {
                    newMonth = _months.Minimum;
                    newYear += 1;
                }
            }

            return new Period(newMonth, newYear);
        }
        public Period Reset(DateTime dateTime) {
            Current = new Period(dateTime);
            return Current;
        }

        public PeriodCycler() : this(new Period()){
        }
        public PeriodCycler(Period period) {
            if(period == null) {
                throw new ArgumentNullException(nameof(period));
            }

            Current = period;
            _months = new Int32Range(1, 12);            
        }
    }
}
