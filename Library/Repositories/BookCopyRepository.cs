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

        public void Add(BookCopy bc)
        {
            context.BookCopies.Add(bc);
        }

        public void Remove(BookCopy bc)
        {
            context.BookCopies.Remove(bc);
        }

        public BookCopy Find(int pk)
        {
            return context.BookCopies.Find(pk);
        }

        public IEnumerable<BookCopy> All()
        {
            return context.BookCopies;
        }

        public void Edit(BookCopy bc)
        {
            // Because the object b was retrieved through the same context, we don't need to do a lookup. 
            // We can just tell the context to save any changes that happened.
            context.SaveChanges();
            Debug.WriteLine("Edited: " + bc);
            // Then why do we still pass the Book object all the way to the repository? Because the service
            // layer doesn't know we use EF. If in the future we decide to switch EF to something else, 
            // we won't have to change the service layer.
        }
    }
}
