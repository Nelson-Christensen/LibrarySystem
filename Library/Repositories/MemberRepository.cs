using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using System.Diagnostics;

namespace Library.Repositories
{
    public class MemberRepository : IRepository<Member, int>
    {
        LibraryContext context;

        public MemberRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Adds the member to the database and saves changes.
        /// </summary>
        /// <param name="m">The Member to be added</param>
        public void Add(Member m)
        {
            context.Members.Add(m);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the input member from the database and save changes.
        /// </summary>
        /// <param name="m">The Member to be removed</param>
        public void Remove(Member m)
        {
            context.Members.Remove(m);
            context.SaveChanges();
        }

        /// <summary>
        /// Finds the member with the ID that matches input.
        /// </summary>
        /// <param name="pk">The ID of the Member that you want to find</param>
        /// <returns>Returns the Member that matches the ID</returns>
        public Member Find(int pk)
        {
            return context.Members.Find(pk);
        }

        /// <summary>
        /// Gets all members from the database.
        /// </summary>
        /// <returns>Returns a collection of all Members that exist in the datbase</returns>
        public IEnumerable<Member> All()
        {
            return context.Members;
        }

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        /// <param name="m">Irrelevant value, always saves all changes to all db entries.</param>
        public void Edit(Member m)
        {
            context.SaveChanges();
        }
    }
}