using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{   /// <summary>
/// handles interaction between gui and memberRepository
/// </summary>
    class MemberService : IService
    {
        public event EventHandler Updated;

        MemberRepository memberRepository;
        /// <summary>
        /// retrieves all members in database
        /// </summary>
        /// <returns>returns all members</returns>
        public IEnumerable<Member> All()
        {
            return memberRepository.All();
        }

        public IEnumerable<string> GetAllMemberNames()
        {
            return memberRepository.All().Select(a => a.ToString()).ToList();
        }

        /// <summary>
        /// Fetches all member references with names that match input string
        /// </summary>
        /// <returns>returns a list of names that matches search criteria</returns>
        public Member GetMemberByName(string input)
        {
            return memberRepository.All()
                .Where(m => m.Name == input)
                .Select(a => a)
                .FirstOrDefault();
        }

        /// <summary>
        /// allows the service to create its own repository
        /// </summary>
        /// <param name="rFactory"></param>
        public MemberService(RepositoryFactory rFactory)
        {
            this.memberRepository = rFactory.CreateMemberRepository();
        }
        /// <summary>
        /// Adds a member to the repository
        /// </summary>
        /// <param name="m"></param>
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

        /// <summary>
        /// removes a member from the repository
        /// </summary>
        /// <param name="m"></param>
        public void Remove(Member m)
        {
            memberRepository.Remove(m);
        }

        /// <summary>
        /// edits a repository reference
        /// </summary>
        /// <param name="m"></param>
        public void Edit(Member m)
        {
            memberRepository.Edit(m);
            var e = EventArgs.Empty;
            OnUpdated(e);
        }

        /// <summary>
        /// finds in repository the match to inputted string. Matches lowercase characters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns a list of members that contains the string input</returns>
        public IEnumerable<Member> GetAllThatContainsInName(string input)
        {
            return from m in memberRepository.All()
                where m.Name.ToLower().Contains(input.ToLower())
                select m;
        }
    }


}
