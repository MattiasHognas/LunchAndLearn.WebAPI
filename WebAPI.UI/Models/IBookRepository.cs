using System.Collections.Generic;

namespace WebAPI.UI.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        Book Add(Book item);
        void Remove(int id);
        bool Update(Book item);
    }
}