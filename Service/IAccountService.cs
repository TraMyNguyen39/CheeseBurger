using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service
{
    public interface IAccountService
    {
        Account GetAccount(string email, string password);
        string GetNamebyID(int idAccount, bool isStaff);
        string GetStaffRole (int idStaff);
        string GetPasswordbyID(int idAccount);
        void ChangePassword(int idAccount, string newPassword);
        void AddNewAccount(string email, string password);

    }
}
