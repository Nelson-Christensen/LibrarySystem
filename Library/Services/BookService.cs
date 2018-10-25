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
        /// <returns>Returns all books that match search criteria</returns>
        public IEnumerable<Book> GetAllThatContainsInTitle(string input)
        {
            return from b in bookRepository.All()
            where b.Title.Contains(input)
            select b;
        }

        /// <summary>
        /// Retrieves all books from the database that are written by a specific Author
        /// </summary>
        /// <param name="input">String to search for Author by</param>
        /// <returns>Returns all books that are written by author</returns>
        public IEnumerable<Book> GetAllThatContainsAuthor(string input)
        {
            //var matchingAuthors = from a in authorRepository.All()
            //                      where a.Name.Contains(input)
            //                      select a;
            //var matchingBooks = bookRepository.All()
            //    .Where(b => b.Authors.Where(a => a.Name == input))
            //    .SelectMany(b => b.Title);
            //return matchingBooks.ToList();
            //return from b in bookRepository.All()
            //       join a in authorRepository.All()
            //       on b.Authors equals a.Books.Where(bk => bk.Id = b.Id)
            //       where a.Name.Contains(input)
            //       select b;

            // Selects all books from bookRepo, then checks to see if any of their authors matches the input and selects it for return.
            return from b in bookRepository.All()
                   where b.Authors.Any( a => a.Name == input)
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
