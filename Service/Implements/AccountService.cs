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
    }
}
