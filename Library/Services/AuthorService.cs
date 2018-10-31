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
    /// Handles interaction between GUI and the AuthorRepository(Database)
    /// </summary>
    class AuthorService : IService
    {
        public event EventHandler Updated;

        AuthorRepository authorRepository;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public AuthorService(RepositoryFactory rFactory)
        {
            this.authorRepository = rFactory.CreateAuthorRepository();
        }

        public IEnumerable<Author> All()
        {
            return authorRepository.All();
        }

        /// <summary>
        /// Adds author to database and notifies subscribers of the update.
        /// </summary>
        /// <param name="a">Author to be added to DB</param>
        public void Add(Author a)
        {
            authorRepository.Add(a);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// Removes the Author from the database and notifies subscribers of the update.
        /// </summary>
        /// <param name="a">Author reference to be removed from the DB</param>
        public void Remove(Author a)
        {
            authorRepository.Remove(a);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// Searches all authors to find if any author has the input name, if so, it returns that author
        /// </summary>
        /// <param name="input">The string to search for authors by</param>
        /// <returns>Returns the first author in the database with a name that matches input string.</returns>
        public Author GetAuthorByName(string input)
        {
            return (from a in authorRepository.All()
                   where a.Name == input
                   select a).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all authors from the database and returns their names in a collection.
        /// </summary>
        /// <returns>Returns a collection of strings of all author names</returns>
        public IEnumerable<string> GetAllAuthorNames()
        {
            return authorRepository.All().Select(a => a.Name).ToList();
        }

        /// <summary>
        /// Checks if an author with a specific name exists in the Database
        /// </summary>
        /// <param name="input">The string to search for authors by</param>
        /// <returns>Returns true if an author with the input name exists in the database, otherwise returns false</returns>
        public bool AuthorExist(string input)
        {
            if (GetAuthorByName(input) == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Notifies subscribers that authorRepository has been updated.
        /// </summary>
        /// <param name="e">EventArgs to send to event subscribers</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            // Checks to see if there are any subscribers to Updated, if so, it invokes the event.
            Updated?.Invoke(this, e);
        }
    }
}