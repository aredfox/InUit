using InUit.Model.Periods;
using System;
using System.Collections.Generic;

namespace InUit.Model.Bookkeeping
{
    public class InMemoryBookRepository : IBookRepository
    {
        private IDictionary<string, Book> _books;

        public InMemoryBookRepository() {
            _books = new Dictionary<string, Book>();
        }

        public Book GetOrCreate(Period period) {
            if(period == null) {
                throw new ArgumentNullException(nameof(period));
            }

            var key = period.Code;
            if (!_books.ContainsKey(key)) {
                _books.Add(period.Code, new Book(period));
            }

            return _books[period.Code];
        }

        public Book Save(Book book) {
            if(book == null) {
                throw new ArgumentNullException(nameof(book));
            }

            var bookOnDisk = GetOrCreate(book.Period);
            var bookToSave = MergeChanges(bookOnDisk, book);

            _books[book.Period.Code] = bookToSave;

            return _books[book.Period.Code];
        }

        private Book MergeChanges(Book book1, Book book2) {
            // TODO: merge strategy
            return book2;
        }
    }
}
