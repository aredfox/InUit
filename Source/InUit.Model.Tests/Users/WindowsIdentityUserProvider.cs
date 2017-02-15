using InUit.Model.Users;
using Kf;
using System.Diagnostics;
using System.Security.Principal;
using Xunit;

namespace InUit.Model.Tests.Users
{
    public class WindowsIdentityUserProvider
    {
        [Fact]
        void ReturnsCorrectLoggedInUser() {
            var userName = WindowsIdentity.GetCurrent().Name;
            var sut = new User(WindowsIdentity.GetCurrent().Name);            
            Assert.Equal(userName.ToLower(), sut.LogonName);
            Assert.True(sut.HasDomain);            
        }
    }
}
