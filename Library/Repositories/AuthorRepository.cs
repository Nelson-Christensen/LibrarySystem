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

        /// <summary>
        /// Adds the author to the database and saves changes.
        /// </summary>
        /// <param name="a">The Author to be added</param>
        public void Add(Author a)
        {
            context.Authors.Add(a);
        }

        /// <summary>
        /// Removes the input author from the database and save changes.
        /// </summary>
        /// <param name="a">The Author to be removed</param>
        public void Remove(Author a)
        {
            context.Authors.Remove(a);
        }

        /// <summary>
        /// Finds the author with the ID that matches input.
        /// </summary>
        /// <param name="pk">The ID of the Author that you want to find</param>
        /// <returns>Returns the Author that matches the ID</returns>
        public Author Find(int pk)
        {
            return context.Authors.Find(pk);
        }

        /// <summary>
        /// Gets all authors from the database.
        /// </summary>
        /// <returns>Returns a collection of all Authors that exist in the datbase</returns>
        public IEnumerable<Author> All()
        {
            return context.Authors;
        }

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        /// <param name="a">Irrelevant value, always saves all changes to all db entries.</param>
        public void Edit(Author a)
        {
            context.SaveChanges();
            Debug.WriteLine("Edited: " + a);
        }
    }
}