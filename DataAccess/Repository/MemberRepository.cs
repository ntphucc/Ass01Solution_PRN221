using DataAccess.DataAcces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member GetMemberByID(int MemberId) => MemberDAO.Instance.GetMemberByID(MemberId);
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMemberList();
        public void InsertMember(Member Member) => MemberDAO.Instance.AddNew(Member);
        public void DeleteMember(int MemberId) => MemberDAO.Instance.Remove(MemberId);
        public void UpdateMember(Member Member) => MemberDAO.Instance.Update(Member);

        public Task<Member> Login(string email, string password) => MemberDAO.Instance.Login(email, password);
    }
}
