using System;
using InUit.Model.Periods;
using Newtonsoft.Json;
using System.IO;

namespace InUit.Model.Bookkeeping
{
    public class JsonBookRepository : IBookRepository
    {
        private readonly AppSettings _appSettings;

        public JsonBookRepository(AppSettings appSettings) {
            if(appSettings == null) {
                throw new ArgumentNullException(nameof(appSettings));
            }

            _appSettings = appSettings;
        }

        public Book GetOrCreate(Period period) {
            var book = Get(period);
            if(book != null) {
                return book;
            }

            var newBook = new Book(period);
            return newBook;
        }

        public Book Get(Period period) {
            var jsonBookFileName = $"{period.Code}.json";
            if (File.Exists(Path.Combine(_appSettings.WorkingDirectory.FullName, jsonBookFileName))) {
                var jsonBook = JsonConvert.DeserializeObject<Book>(File.ReadAllText(Path.Combine(_appSettings.WorkingDirectory.FullName, jsonBookFileName)));
                return jsonBook;
            }

            return null;
        }

        public Book Save(Book book) {
            var jsonBook = JsonConvert.SerializeObject(book, Formatting.Indented);
            var jsonBookFileName = $"{book.Period.Code}.json";
            File.WriteAllText(Path.Combine(_appSettings.WorkingDirectory.FullName, jsonBookFileName), jsonBook);

            return Get(book.Period);
        }
    }
}
