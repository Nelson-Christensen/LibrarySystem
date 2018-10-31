using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Diagnostics;

namespace Library.Repositories
{
    public class LoanRepository : IRepository<Loan, int>
    {
        LibraryContext context;

        public LoanRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Adds the loan to the database and saves changes.
        /// </summary>
        /// <param name="l">The Loan to be added</param>
        public void Add(Loan l)
        {
            context.Loans.Add(l);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the input loan from the database and save changes.
        /// </summary>
        /// <param name="l">The Loan to be removed</param>
        public void Remove(Loan l)
        {
            context.Loans.Remove(l);
            context.SaveChanges();
        }

        /// <summary>
        /// Finds the Loan with the ID that matches input.
        /// </summary>
        /// <param name="pk">The ID of the Loan that you want to find</param>
        /// <returns>Returns the Loan that matches the ID</returns>
        public Loan Find(int pk)
        {
            return context.Loans.Find(pk);
        }

        /// <summary>
        /// Gets all Loans from the database. Includes BookCopy and Member to make sure that they are loaded when you access the loans, otherwise it could load with null values in their place.
        /// </summary>
        /// <returns>Returns a collection of all Loans that exist in the datbase</returns>
        public IEnumerable<Loan> All()
        {
            return context.Loans.Include("BookCopy").Include("Member");
        }

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        /// <param name="l">Irrelevant value, always saves all changes to all db entries.</param>
        public void Edit(Loan l)
        {
            context.SaveChanges();
        }
    }
}