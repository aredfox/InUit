using System;

namespace InUit.Model.Bookkeeping
{
    public class Line
    {
        public DateTimeOffset When { get; set; }
        public string Name { get; set; }
        public LineCategory Category { get; set; }
        public bool IsOk { get; set; }

        public override string ToString() {
            return $"{When.ToString("dd/MM")} {Name}";
        }
    }
}
