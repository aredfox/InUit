using Kf;
using System;

namespace InUit.Model.Users
{
    public class User
    {
        public string LogonName { get; }
        public string ShortLogonName { get; }
        public string Domain { get; }
        public bool HasDomain => !String.IsNullOrEmpty(Domain) && !String.IsNullOrWhiteSpace(Domain);

        public User(string logonName) {
            if(String.IsNullOrEmpty(logonName) || String.IsNullOrWhiteSpace(logonName)) {
                throw new ArgumentNullException(nameof(logonName));
            }

            LogonName = logonName.Trim().ToLower();
            Domain = LogonName.SubstringSafe(0, LogonName.IndexOf(@"\"));
            ShortLogonName = HasDomain
                ? LogonName.Replace(String.Concat(Domain, @"\"), "")
                : LogonName;
        }
    }
}
