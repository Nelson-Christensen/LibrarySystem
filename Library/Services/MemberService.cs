﻿using Library.Models;
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

        public MemberService(RepositoryFactory rFactory)
        {
            this.memberRepository = rFactory.CreateMemberRepository();
        }
    }


}
