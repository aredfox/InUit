using InUit.Model.Users;
using System;
using Xunit;

namespace InUit.Model.Tests.Users
{
    public class UserTests
    {
        private string _logonNameWithDomain = @"SYSTEM\User";
        private string _logonNameWithoutDomain = @"User";

        [Fact]
        void CtorThrowsWhenNullString() {
            Assert.Throws<ArgumentNullException>(() => {
                new User(null);
            });
        }

        [Fact]
        void CtorThrowsWhenEmptyString() {
            Assert.Throws<ArgumentNullException>(() => {
                new User("");
            });
        }

        [Fact]
        void CtorThrowsWhenWhitespaceString() {
            Assert.Throws<ArgumentNullException>(() => {
                new User("   ");
            });
        }

        [Fact]
        void CtorPopulatesLogonName() {
            var sut = new User(_logonNameWithDomain);
            var expected = _logonNameWithDomain.ToLower();
            Assert.Equal(expected, sut.LogonName);
        }

        [Fact]
        void CtorPopulatesShortLogonName() {
            var sut = new User(_logonNameWithDomain);
            var expected = "user";
            Assert.Equal(expected, sut.ShortLogonName);
        }

        [Fact]
        void CtorPopulatesDomain() {
            var sut = new User(_logonNameWithDomain);
            var expected = "system";
            Assert.Equal(expected, sut.Domain);
        }

        [Fact]
        void CtorPopulatesHasDomain() {
            var sut = new User(_logonNameWithDomain);
            Assert.True(sut.HasDomain);
        }

        [Fact]
        void CtorPopulatesHasDomainWhenNoDomainIsGiven() {
            var sut = new User(_logonNameWithoutDomain);
            Assert.False(sut.HasDomain);
        }

        [Fact]
        void CtorPopulatesShortLogonNameNoDomainIsGiven() {
            var sut = new User(_logonNameWithoutDomain);
            var expected = _logonNameWithoutDomain.ToLower();
            Assert.Equal(expected, sut.ShortLogonName);
        }
    }
}
