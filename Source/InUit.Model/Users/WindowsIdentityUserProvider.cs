using System;
using System.Security.Principal;

namespace InUit.Model.Users
{
    public class WindowsIdentityUserProvider : IUserProvider
    {
        public User GetLoggedInUser() {
            var windowsIdentityUser = WindowsIdentity.GetCurrent();
            return new User(windowsIdentityUser.Name);
        }
    }
}
