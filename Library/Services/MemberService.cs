using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class MemberService : IService
    {
        public event EventHandler Updated;

        MemberRepository memberRepository;

        public IEnumerable<Member> All()
        {
            return memberRepository.All();
        }

        public IEnumerable<string> GetAllMemberNames()
        {
            return memberRepository.All().Select(a => a.ToString()).ToList();
        }

        public Member GetMemberByName(string input)
        {
            return memberRepository.All()
                .Where(m => m.Name == input)
                .Select(a => a)
                .FirstOrDefault();
        }

        public MemberService(RepositoryFactory rFactory)
        {
            this.memberRepository = rFactory.CreateMemberRepository();
        }
        public void Add(Member m)
        {
            memberRepository.Add(m);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            // Checks to see if there are any subscribers to Updated, if so, it invokes the event.
            Updated?.Invoke(this, e);
        }

        public void Remove(Member m)
        {
            memberRepository.Remove(m);
        }

        public void Edit(Member m)
        {
            memberRepository.Edit(m);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        public IEnumerable<Member> GetAllThatContainsInTitle(string input)
        {
            return from m in memberRepository.All()
                where m.Name.ToLower().Contains(input.ToLower())
                select m;
        }
    }


}
