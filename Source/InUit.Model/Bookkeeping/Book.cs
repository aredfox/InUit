using InUit.Model.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using Kf;

namespace InUit.Model.Bookkeeping
{
    public class Book
    {
        public Period Period { get; }
        public IEnumerable<Line> Lines { get { return _lines; } }
        private List<Line> _lines;

        public Book(Period period) {
            if(period == null) {
                throw new ArgumentNullException(nameof(period));
            }

            Period = period;
            _lines = new List<Line>();
        }

        public void AddLine(Line line) {
            if (_lines.Where(l => l.ToDebugString().Equals(line.ToDebugString())).Count() == 0) {
                _lines.Add(line);
            }
        }
        public void UpdateLine(Line line, bool isOk) {
            var updateLine = _lines.Where(l => l.ToDebugString().Equals(line.ToDebugString())).SingleOrDefault();
            if (updateLine != null) {
                updateLine.IsOk = isOk;
            }
        }
    }
}
