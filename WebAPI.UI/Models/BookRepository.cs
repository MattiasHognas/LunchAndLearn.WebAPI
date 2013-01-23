using System.Collections.Generic;

namespace WebAPI.UI.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStore _db = new BookStore();

        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public Book Add(Book item)
        {
            _db.Books.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            Book book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public bool Update(Book item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return true;
        }
    }
}