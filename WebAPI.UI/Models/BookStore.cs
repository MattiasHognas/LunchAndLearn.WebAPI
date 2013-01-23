using System.Data.Entity;

namespace WebAPI.UI.Models
{
    public class BookStore : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}