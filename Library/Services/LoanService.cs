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
    class LoanService : IService
    {
        public event EventHandler Updated;
        LoanRepository loanRepository;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public LoanService(RepositoryFactory rFactory)
        {
            this.loanRepository = rFactory.CreateLoanRepository();
        }


        /// <summary>
        /// Retrieves all loans from the repository.
        /// </summary>
        /// <returns>Returns a collection of all loans currently in the repository</returns>
        public IEnumerable<Loan> All()
        {
            return loanRepository.All();
        }

        /// <summary>
        /// Adds loan to database and notifies subscribers of the update.
        /// </summary>
        /// <param name="l">Loan reference to be added to DB</param>
        public void Add(Loan l)
        {
            loanRepository.Add(l);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// Removes the loan from the database and notifies subscribers of the update.
        /// </summary>
        /// <param name="l">Loan reference to be removed from the DB</param>
        public void Remove(Loan l)
        {
            loanRepository.Remove(l);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// Notifies subscribers that loanRepository has been updated.
        /// </summary>
        /// <param name="e">EventArgs to send to event subscribers</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            // Checks to see if there are any subscribers to Updated, if so, it invokes the event.
            Updated?.Invoke(this, e);
        }
    }
}