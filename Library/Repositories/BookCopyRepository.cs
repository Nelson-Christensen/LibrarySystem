using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Diagnostics;

namespace Library.Repositories
{
    public class BookCopyRepository : IRepository<BookCopy, int>
    {
        LibraryContext context;

        public BookCopyRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Adds the bookcopy to the database and saves changes.
        /// </summary>
        /// <param name="bc">The BookCopy to be added</param>
        public void Add(BookCopy bc)
        {
            context.BookCopies.Add(bc);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the input BookCopy from the database and save changes.
        /// </summary>
        /// <param name="bc">The BookCopy to be removed</param>
        public void Remove(BookCopy bc)
        {
            context.BookCopies.Remove(bc);
            context.SaveChanges();
        }

        /// <summary>
        /// Finds the BookCopy with the ID that matches input.
        /// </summary>
        /// <param name="pk">The ID of the BookCopy that you want to find</param>
        /// <returns>Returns the BookCopy that matches the ID</returns>
        public BookCopy Find(int pk)
        {
            return context.BookCopies.Find(pk);
        }

        /// <summary>
        /// Gets all BookCopies from the database.
        /// </summary>
        /// <returns>Returns a collection of all BookCopies that exist in the datbase</returns>
        public IEnumerable<BookCopy> All()
        {
            return context.BookCopies;
        }

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        /// <param name="b">Irrelevant value, always saves all changes to all db entries.</param>
        public void Edit(BookCopy bc)
        {
            context.SaveChanges();
        }
    }
}
