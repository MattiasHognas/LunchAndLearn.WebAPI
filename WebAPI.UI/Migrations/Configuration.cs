using WebAPI.UI.Models;
using System.Data.Entity.Migrations;

namespace WebAPI.UI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI.UI.Models.BookStore>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore context)
        {
            context.Books.AddOrUpdate(
                  p => p.Name,
                  new Book { Id = 1, Name = "Alfa", Price = 100 },
                  new Book { Id = 2, Name = "Beta", Price = 10000 },
                  new Book { Id = 3, Name = "Gamma", Price = 500 }
                );
        }
    }
}
