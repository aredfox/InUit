using InUit.Model.Periods;
using System;
using Xunit;

namespace InUit.Model.Tests.Periods
{
    public class PeriodTests
    {
        [Fact]
        void PeriodStringConstructorReturnsCorrectPeriod() {
            for(var month = 1; month <= 12; month++) {
                var sut = new Period($"2015{month.ToString("00")}");
                var expected = $"2015{month.ToString("00")}";
                Assert.Equal(expected, sut.Code);
            }            
        }

        [Fact]
        void PeriodStringConstructorThrowPeriodExceptionWhenNotLongEnough() {
            Assert.Throws<PeriodException>(() => {
                var sut = new Period("1509");
            });
        }
        [Fact]
        void PeriodStringConstructorThrowPeriodExceptionWhenTooLong() {
            Assert.Throws<PeriodException>(() => {
                var sut = new Period("2015/09/21");
            });
        }

        [Fact]
        void PeriodStringConstructorThrowPeriodExceptionWhenMalformed() {
            Assert.Throws<PeriodException>(() => {
                var sut = new Period("2015AA");
            });
        }

        [Fact]
        void PeriodStringConstructorThrowPeriodExceptionWhenOutOfRangeUpper() {
            Assert.Throws<PeriodException>(() => {
                var sut = new Period("201513");
            });
        }

        [Fact]
        void PeriodStringConstructorThrowPeriodExceptionWhenOutOfRangeLower() {
            Assert.Throws<PeriodException>(() => {
                var sut = new Period("201500");
            });
        }

        [Fact]
        void DefaultConstructorUsesCurrentDateTime() {
            var sut = new Period();
            var expected = $"{DateTimeOffset.Now.Year.ToString("0000")}{DateTimeOffset.Now.Month.ToString("00")}";
            Assert.Equal(expected, sut.Code);
        }

        [Fact]
        void DateTimeConstructorUsesGivenDateTime() {
            var sut = new Period(new DateTime(2020, 11, 25));
            var expected = $"202011";
            Assert.Equal(expected, sut.Code);
        }

        [Fact]
        void YearMontConstructorThrowsWhenOutOfRangeUpper() {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var sut = new Period(13, 1950);
            });
        }

        [Fact]
        void YearMontConstructorThrowsWhenOutOfRangeLower() {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var sut = new Period(0, 1950);
            });
        }
    }
}
