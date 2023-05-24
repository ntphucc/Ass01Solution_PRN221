using DataAccess.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memberId);
        void InsertMember(Member car);
        void DeleteMember(int memberId);
        void UpdateMember(Member car);
        Task<Member> Login(string email, string password);
    }
}
