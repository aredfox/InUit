using InUit.Model.Bookkeeping;
using InUit.Model.Periods;
using InUit.Model.Users;
using System;
using System.IO;

namespace InUit.Model
{
    public class AppContext
    {
        public IUserProvider UserProvider { get; }
        public Period CurrentPeriod => new Period();
        public PeriodCycler Period { get; }
        public IBookRepository Books { get; }
        public AppSettings Settings { get; }        

        public AppContext(IUserProvider userProvider, IBookRepository books) {
            if(userProvider == null) {
                throw new ArgumentNullException(nameof(userProvider));
            }
            if(books == null) {
                throw new ArgumentNullException(nameof(books));
            }

            UserProvider = userProvider;
            Period = new PeriodCycler();
            Books = books;
            Settings = new AppSettings();
        }
    }
}
