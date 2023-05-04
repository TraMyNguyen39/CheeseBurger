using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service
{
    public interface IAccountService
    {
        Account GetAccount(string email, string password);
        string GetNamebyID(int idAccount, bool isStaff);
        string GetStaffRole (int idStaff);
    }
}
