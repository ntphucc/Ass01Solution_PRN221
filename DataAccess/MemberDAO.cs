using DataAccess.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMemberList()
        {
            var members = new List<Member>();
            try
            {
                using var context = new FStoreContext();
                members = context.Members.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public Member GetMemberByID(int memberID)
        {
            Member member = null;
            try
            {
                using var context = new FStoreContext();
                member = context.Members.SingleOrDefault(c => c.MemberId == memberID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddNew(Member member)
        {
            try
            {
                Member _Member = GetMemberByID(member.MemberId);
                if (_Member == null)
                {
                    using var context = new FStoreContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    using var context = new FStoreContext();
                    context.Members.Update(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(int memberID)
        {
            try
            {
                Member member = GetMemberByID(memberID);
                if (member != null)
                {
                    using var context = new FStoreContext();
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Member> Login(string email, string password)
        {
            var context = new FStoreContext();
            return await context.Members.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public static bool IsUserAdmin(string username)
        {
            return username.Equals("admin", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsUserRegularUser(string username)
        {
            return !IsUserAdmin(username);
        }
    }
}
