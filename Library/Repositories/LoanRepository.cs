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

        public void Add(Loan l)
        {
            context.Loans.Add(l);
            context.SaveChanges();
        }

        public void Remove(Loan l)
        {
            context.Loans.Remove(l);
            context.SaveChanges();
        }

        public Loan Find(int pk)
        {
            return context.Loans.Find(pk);
        }

        public IEnumerable<Loan> All()
        {
            return context.Loans;
        }

        public void Edit(Loan l)
        {
            context.SaveChanges();
        }
    }
}