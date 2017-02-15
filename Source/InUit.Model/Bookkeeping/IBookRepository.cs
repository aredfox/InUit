using InUit.Model.Periods;

namespace InUit.Model.Bookkeeping
{
    public interface IBookRepository
    {
        Book GetOrCreate(Period period);
        Book Save(Book book);                
    }
}
