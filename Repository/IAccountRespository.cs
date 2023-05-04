using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IAccountRespository
    {
        Account GetAccount(string email, string password);
        string GetNamebyID(int idAccount, bool isStaff);
        string GetStaffRole(int idStaff);
    }
}
