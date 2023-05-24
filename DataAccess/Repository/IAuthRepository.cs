using DataAccess.DataAcces;

namespace DataAccess.Repository
{
    public interface IAuthRepository 
    {
        //abstract method (khong dinh nghia body)
        public Member checkLogin(string username, string password);
    }
}
