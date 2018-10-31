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
    /// Handles interaction between GUI and the loanRepository(Database)
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
        /// Retrieves all loans from books that contain the input string in their title
        /// </summary>
        /// <param name="input">String to search by</param>
        /// <returns>Returns Collection of Loans that match search criteria</returns>
        public IEnumerable<Loan> GetAllThatContainsTitle(string input)
        {
            return from l in loanRepository.All()
                   where l.BookCopy.Book.Title.ToLower().Contains(input.ToLower())
                   select l;
        }

        /// <summary>
        /// Retrieves all loans from all members that have names that include the input string.
        /// </summary>
        /// <param name="input">String to search by</param>
        /// <returns>Returns Collection of Loans that match search criteria</returns>
        public IEnumerable<Loan> GetAllThatContainsMember(string input)
        {
            return from l in loanRepository.All()
                   where l.Member.Name.ToLower().Contains(input.ToLower())
                   select l;
        }


        /// <summary>
        /// Checks all loans to see if they have been returned or not, and retrieves the loans that currently hasnt been returned.
        /// </summary>
        /// <returns>Returns a collection of all loans that are currently active(not returned)</returns>
        public IEnumerable<Loan> GetAllActiveLoans()
        {
            return from l in loanRepository.All()
                   where l.IsReturned == false
                   select l;
        }

        /// <summary>
        /// Retrieves a collection of loans that have not been returned and their dueDates have passed.
        /// </summary>
        /// <returns>Returns a collection of all loans that are currently overdue(dueDate passed and not returned)</returns>
        public IEnumerable<Loan> GetAllOverdueLoans()
        {
            return from l in loanRepository.All()
                   where l.IsReturned == false && l.DueDate < DateTime.Now
                   select l;
        }


        /// <summary>
        /// Combines the result of two collections and returns a collection of all objects that exist in both. Used to combine filters.
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns>Returns a collection of objects that exist in both lists</returns>
        public IEnumerable<Loan> CombineFilteredLists(IEnumerable<Loan> list1, IEnumerable<Loan> list2)
        {
            return list1.Intersect(list2);
        }

        /// <summary>
        /// Returns the loan with specific primary key (Id)
        /// </summary>
        /// <param name="pk"></param>
        /// <returns>Returns loan that has the specified primary key</returns>
        public Loan Find(int pk)
        {
            return loanRepository.Find(pk);
        }

        /// <summary>
        /// Returns the specific loan.
        /// </summary>
        /// <param name="l">The Loan to be returned</param>
        public void ReturnLoan(Loan l)
        {
            ReturnLoan(l, DateTime.Now);
        }

        /// <summary>
        /// Returns the specific loan.
        /// </summary>
        /// <param name="l">The Loan to be returned</param>
        /// <param name="returnTime">The DateTime that the loan was returned. If left out, it will be returned at current time.</param>
        public void ReturnLoan(Loan l, DateTime returnTime)
        {
            l.ReturnDate = returnTime;
            loanRepository.Edit(l);
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