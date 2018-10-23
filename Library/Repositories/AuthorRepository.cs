using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Diagnostics;

namespace Library.Repositories
{
    public class AuthorRepository : IRepository<Author, int>
    {
        LibraryContext context;

        public AuthorRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(Author a)
        {
            context.Authors.Add(a);
        }

        public void Remove(Author a)
        {
            context.Authors.Remove(a);
        }

        public Author Find(int pk)
        {
            return context.Authors.Find(pk);
        }

        public IEnumerable<Author> All()
        {
            return context.Authors;
        }

        public void Edit(Author a)
        {
            // Because the object b was retrieved through the same context, we don't need to do a lookup. 
            // We can just tell the context to save any changes that happened.
            context.SaveChanges();
            Debug.WriteLine("Edited: " + a);
            // Then why do we still pass the Book object all the way to the repository? Because the service
            // layer doesn't know we use EF. If in the future we decide to switch EF to something else, 
            // we won't have to change the service layer.
        }
    }
}