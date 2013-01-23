using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Query;
using WebAPI.UI.Models;

namespace WebAPI.UI.Controllers
{
    public class BooksController : ApiController
    {
        private static IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public IEnumerable<Book> GetAllBooks(ODataQueryOptions options)
        {
            return options.ApplyTo(_repository.GetAll().AsQueryable()) as IQueryable<Book>;
        }

        public Book GetBook(int id)
        {
            var book = _repository.Get(id);
            if (book == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return book;
        }

        public HttpResponseMessage PostBook(Book book)
        {
            book = _repository.Add(book);
            var response = Request.CreateResponse(HttpStatusCode.Created, book);
            var uri = Url.Route(null, new {id = book.Id});
            if (uri != null) response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        public void PutBook(int id, Book book)
        {
            book.Id = id;
            if (!_repository.Update(book))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }

        public HttpResponseMessage DeleteBook(int id)
        {
            _repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}