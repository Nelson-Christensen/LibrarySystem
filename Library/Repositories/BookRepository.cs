using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Diagnostics;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        LibraryContext context;

        public BookRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Adds the book to the database and saves changes.
        /// </summary>
        /// <param name="b">The Book to be added</param>
        public void Add(Book b)
        {
            context.Books.Add(b);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the input book from the database and save changes.
        /// </summary>
        /// <param name="b">The Book to be removed</param>
        public void Remove(Book b)
        {
            context.Books.Remove(b);
            context.SaveChanges();
        }

        /// <summary>
        /// Finds the book with the ID that matches input.
        /// </summary>
        /// <param name="pk">The ID of the book that you want to find</param>
        /// <returns>Returns the book that matches the ID</returns>
        public Book Find(int pk)
        {
            return context.Books.Find(pk);
        }

        /// <summary>
        /// Gets all books from the database.
        /// </summary>
        /// <returns>Returns a collection of all books that exist in the datbase</returns>
        public IEnumerable<Book> All()
        {
            return context.Books;
        }

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        /// <param name="b">Irrelevant value, always saves all changes to all db entries.</param>
        public void Edit(Book b)
        {
            // Because the object b was retrieved through the same context, we don't need to do a lookup. 
            // We can just tell the context to save any changes that happened.
            context.SaveChanges();
            // Then why do we still pass the Book object all the way to the repository? Because the service
            // layer doesn't know we use EF. If in the future we decide to switch EF to something else, 
            // we won't have to change the service layer.
        }
    }
}