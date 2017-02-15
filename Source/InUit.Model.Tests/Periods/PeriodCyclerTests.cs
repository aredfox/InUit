using InUit.Model.Periods;
using Xunit;

namespace InUit.Model.Tests.Periods
{
    public class PeriodCyclerTests
    {
        [Fact]
        void NextReturnsCorrectPeriod() {
            var sut = new PeriodCycler(new Period("201509"));
            var expected = "201510";
            Assert.Equal(expected, sut.Next().Code);
        }

        [Fact]
        void NextReturnsCorrectPeriodOnEdge() {
            var sut = new PeriodCycler(new Period("201512"));
            var expected = "201601";
            Assert.Equal(expected, sut.Next().Code);
        }

        [Fact]
        void PreviousReturnsCorrectPeriod() {
            var sut = new PeriodCycler(new Period("201509"));
            var expected = "201508";
            Assert.Equal(expected, sut.Previous().Code);
        }

        [Fact]
        void PreviousReturnsCorrectPeriodOnEdge() {
            var sut = new PeriodCycler(new Period("201501"));
            var expected = "201412";
            Assert.Equal(expected, sut.Previous().Code);
        }
    }
}
