using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRespository accountRespository;

        public AccountService (IAccountRespository accountRespository)
        {
            this.accountRespository = accountRespository;
        }

        public Account GetAccount(string email, string password)
        {
            return accountRespository.GetAccount(email, password);
        }

        public string GetNamebyID(int idAccount, bool isStaff)
        {
            return accountRespository.GetNamebyID(idAccount, isStaff);
        }

        public string GetStaffRole(int idStaff)
        {
           return accountRespository.GetStaffRole(idStaff);
        }       
        public string GetPasswordbyID(int idAccount)
        {
            return accountRespository.GetPasswordbyID(idAccount);
        }
        public void ChangePassword(int idAccount, string newPassword)
        {
            accountRespository.ChangePassword(idAccount, newPassword);
        }
        public void AddNewAccount(string email, string password)
        {
            accountRespository.AddNewAccount(email, password);
        }
        public List<Account> GetListAccount()
        {
            return accountRespository.GetListAccount();
        }
        public int GetIDAccountByMail(string email)
        {
            return accountRespository.GetIDAccountByMail(email);   
        }

    }
}
