using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MemberRepo
{
    public class MemberRepo : IMemberRepo
    {
        public Member Login(string email, string password) => MemberDAO.Login(email, password);
        public void Save(Member member) => MemberDAO.SaveMember(member);
        public void Delete(Member member) => MemberDAO.Delete(member);
        public void Update(Member member) => MemberDAO.Update(member);
        public IList<Member> GetMembers() => MemberDAO.GetMembers();
        public Member GetMember(int id) => MemberDAO.GetMember(id);
        public bool Exist(int id) => MemberDAO.Exist(id);
        public IList<Member> SearchByCompanyName(string name) => MemberDAO.SearchByCompanyName(name);
    }
}
