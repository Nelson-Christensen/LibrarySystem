using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    /// <summary>
    /// Handles interaction between GUI and the bookRepository and authorRepository (Database)
    /// </summary>
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

        BookCopyRepository bookCopyRepository;

        LoanRepository loanRepository;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookService(RepositoryFactory rFactory)
        {
            this.bookRepository = rFactory.CreateBookRepository();
            this.authorRepository = rFactory.CreateAuthorRepository();
            this.bookCopyRepository = rFactory.CreateBookCopyRepository();
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
        /// SLOW TO USE. Combines the result of two collections and returns a collection of all objects that exist in both. Used to combine filters.
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns>Returns a collection of objects that exist in both lists</returns>
        public IEnumerable<Book> CombineFilteredLists(IEnumerable<Book> list1, IEnumerable<Book> list2)
        {
            return list1.Intersect(list2);
        }

        /// <summary>
        /// Checks all books to see if they have book copies without active loans and returns those books.
        /// </summary>
        /// <returns>Returns a collection of all books that has copies not currently out on loan.</returns>
        public IEnumerable<Book> GetAllAvailableBooks()
        {
            // List of all bookCopies currently out on loan.
            var loanedOutCopies = bookCopyRepository.All()
                .Where(bc => bc.Loans
                .Any(l => !l.IsReturned()));

            // List of all bookCopies that are not out on loan, and therefore available.
            var availableCopies = bookCopyRepository.All()
                .Where(bc => !loanedOutCopies.Contains(bc));

            // List of all books that has bookCopies that are currently available.
            var availableBooks = bookRepository.All()
                .Where(b => b.BookCopies != null)
                .Where(b => b.BookCopies
                .Any(bc => availableCopies.Contains(bc)));

            return availableBooks;
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

        /// <summary>
        /// Removes book from database and removes the books authors if no other books are connected to the author.
        /// </summary>
        /// <param name="b">Book to be removed from Database.</param>
        public void Remove(Book b)
        {
            // Searches all authors the book is connected to, to see if they are connected to another book, otherwise, remove the author from DB.
            for (int i = b.Authors.Count() - 1; i >= 0; i--)
            {
                bool keepAuthor = false;
                foreach (Book ab in All()) // Search all books for the specific author.
                {
                    if (ab != b) // Dont match if the currently searching book is the same as the book about to be removed.
                    {
                        if (ab.Authors.Contains(b.Authors[i]))
                        {
                            keepAuthor = true;
                        }
                    }
                }
                if (keepAuthor == false)
                {
                    authorRepository.Remove(b.Authors[i]);
                }
            }

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
