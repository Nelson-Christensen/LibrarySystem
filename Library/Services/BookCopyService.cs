using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Repositories;

namespace Library.Services
{
    /// <summary>
    /// Handles interaction between GUI and the bookCopyRepository(Database)
    /// </summary>
    class BookCopyService : IService
    {
        public event EventHandler Updated;

        /// <summary>
        /// service doesn't need a context but it needs a repository.
        /// </summary>
        BookCopyRepository bookCopyRepository;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookCopyService(RepositoryFactory rFactory)
        {
            this.bookCopyRepository = rFactory.CreateBookCopyRepository();
        }

        public IEnumerable<BookCopy> All()
        {
            return bookCopyRepository.All();
        }

        /// <summary>
        /// Adds input book copy to database and notifies subscribers of the update.
        /// </summary>
        /// <param name="bc">BookCopy reference to be added to DB</param>
        public void Add(BookCopy bc)
        {
            bookCopyRepository.Add(bc);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// Removes the input book from the database and notifies subscribers of the update.
        /// </summary>
        /// <param name="bc">BookCopy reference to be removed from the DB</param>
        public void Remove(BookCopy bc)
        {
            bookCopyRepository.Remove(bc);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        public IEnumerable<BookCopy> GetAllCopiesByBook(Book input)
        {
            return from bc in bookCopyRepository.All()
                   where bc.Book == input
                   select bc;
        }

        /// <summary>
        /// Returns the bookCopy with specific primary key (Id)
        /// </summary>
        /// <param name="pk"></param>
        /// <returns>Returns the bookCopy that has the specified primary key</returns>
        public BookCopy Find(int pk)
        {
            return bookCopyRepository.Find(pk);
        }

        /// <summary>
        /// Notifies subscribers that bookCopyRepository has been updated.
        /// </summary>
        /// <param name="e">EventArgs to send to event subscribers</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            // Checks to see if there are any subscribers to Updated, if so, it invokes the event.
            Updated?.Invoke(this, e);
        }
    }
}
