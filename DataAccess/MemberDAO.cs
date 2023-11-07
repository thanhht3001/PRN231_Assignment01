using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        public static Member Login(string email, string password)
        {
            using (var context = new FStoreDBContext())
            {
                return context.Members.SingleOrDefault(c => c.Email == email && c.Password == password);
            }
        }

        public static IList<Member> GetMembers()
        {
            var list = new List<Member>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Members.Include(c => c.Orders).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static Member GetMember(int id)
        {
            var list = new List<Member>();
            Member Member = new Member();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    list = context.Members.Include(c => c.Orders).ToList();
                    Member = list.SingleOrDefault(c => c.MemberId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Member;

        }
        public static void SaveMember(Member member)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Update(Member member)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Member>(member).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Delete(Member member)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var _member = context.Members.SingleOrDefault(c => c.MemberId == member.MemberId);
                    context.Members.Remove(_member);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IList<Member> SearchByCompanyName(string companyName)
        {
            var list = new List<Member>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    if (companyName != null)
                    {
                        list = context.Members
                            .Include(c => c.Orders)
                            .Where(c => c.CompanyName.Contains(companyName))
                            .ToList();
                    }
                    else
                    {
                        list = context.Members
                            .Include(c => c.Orders)
                            .ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static bool Exist(int id)
        {
            using (var context = new FStoreDBContext())
            {
                return context.Members.Any(c => c.MemberId == id);
            }
        }
    }
}
