using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MemberRepo
{
    public interface IMemberRepo
    {
        Member Login(string email, string password);
        void Save(Member member);
        void Delete(Member member);
        void Update(Member member);
        IList<Member> GetMembers();
        Member GetMember(int id);
        bool Exist(int id);
        IList<Member> SearchByCompanyName(string name);
    }
}
