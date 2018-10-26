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

        public void Add(Member m)
        {
            context.Members.Add(m);
            context.SaveChanges();
        }

        public void Remove(Member m)
        {
            context.Members.Remove(m);
            context.SaveChanges();
        }

        public Member Find(int pk)
        {
            return context.Members.Find(pk);
        }

        public IEnumerable<Member> All()
        {
            return context.Members;
        }

        public void Edit(Member m)
        {
            context.SaveChanges();
        }
    }
}