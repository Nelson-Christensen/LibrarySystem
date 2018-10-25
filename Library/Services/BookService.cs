using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class BookService : IService
    {

        public event EventHandler Updated;

        /// <summary>
        /// service doesn't need a context but it needs a repository.
        /// </summary>
        BookRepository bookRepository;

        /// <summary>
        /// needs AuthorRepository to be able to crossmatch from the author table.
        /// </summary>
        AuthorRepository authorRepository;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookService(RepositoryFactory rFactory)
        {
            this.bookRepository = rFactory.CreateBookRepository();
        }

        /// <summary>
        /// Retrieves all books from database
        /// </summary>
        /// <returns>All books in Database</returns>
        public IEnumerable<Book> All()
        {
            return bookRepository.All();
        }

        /// <summary>
        /// Retrieves all books from database that contains part of the input string
        /// </summary>
        /// <param name="input">String to search by</param>
        /// <returns>Returns Collection of books that match search criteria</returns>
        public IEnumerable<Book> GetAllThatContainsInTitle(string input)
        {
            return from b in bookRepository.All()
            where b.Title.ToLower().Contains(input.ToLower())
            select b;
        }

        /// <summary>
        /// Retrieves all books from the database that has an author which name contains input string
        /// </summary>
        /// <param name="input">String to search for Author by</param>
        /// <returns>Returns Collection of books that are written by input author</returns>
        public IEnumerable<Book> GetAllThatContainsAuthor(string input)
        {
            var bookList = bookRepository.All()
                .Where(b => b.Authors
                        .Any(a => a.Name.ToLower().Contains(input.ToLower())));

            return bookList;
        }

        public IEnumerable<Book> GetAllThatContainsISBN(string input)
        {
            return from b in bookRepository.All()
                   where b.ISBN != null && b.ISBN.ToLower().Contains(input.ToLower())
                   select b;
        }


        /// <summary>
        /// The Edit method makes sure that the given Book object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(Book b)
        {
            bookRepository.Edit(b);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        public void Add(Book b)
        {
            bookRepository.Add(b);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        public void Remove(Book b)
        {
            bookRepository.Remove(b);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            // Checks to see if there are any subscribers to Updated, if so, it invokes the event.
            Updated?.Invoke(this, e);
        }
    }
}
