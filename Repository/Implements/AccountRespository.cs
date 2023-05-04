using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
    public class AccountRespository : IAccountRespository
    {
        private readonly CheeseBurgerContext context;
        public AccountRespository (CheeseBurgerContext context)
        {
            this.context = context;
        }
        public Account GetAccount(string email, string password)
        {
            return context.Accounts.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
        }

        public string GetNamebyID(int idAccount, bool isStaff)
        {
            if (isStaff)
                return context.Staffs.Where(p => p.AccountID == idAccount).FirstOrDefault().StaffName;
            else
                return context.Customers.Where(p => p.AccountID == idAccount).FirstOrDefault().CustomerName;
        }

        public string GetStaffRole(int idAccount)
        {
            var idRole = context.Staffs.Where(p => p.AccountID == idAccount).Select(p => p.RoleID).FirstOrDefault();
            return context.Roles.Where(p => p.RoleID == idRole).Select(p => p.RoleName).FirstOrDefault();
        }
    }
}
