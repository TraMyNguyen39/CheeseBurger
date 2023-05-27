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
        public string GetPasswordbyID(int idAccount)
        {
            return context.Accounts.Where(p => p.AccountID == idAccount).Select(p => p.Password).FirstOrDefault();
        }
        public void ChangePassword(int idAccount, string newPassword)
		{
            var _acc = context.Accounts.FirstOrDefault(p => p.AccountID == idAccount);
            if (_acc != null)
            {
                _acc.Password = newPassword;
                context.SaveChanges();
            }
        }
        public void AddNewAccount(string email, string password)
        {
            var acc = new Account
            {
                Email = email,
                Password = password,
                isDeleted = false,
                isStaff = false
            };
            context.Accounts.Add(acc);
            context.SaveChanges();
        }
        public List<Account> GetListAccount()
        {
            return context.Accounts.Where(p => p.isDeleted == false).Select(p => p).ToList();
        }
        public int GetIDAccountByMail(string email)
        {
            var acc = context.Accounts.Where(p => p.Email.Equals(email)).FirstOrDefault();
            return acc.AccountID;
        }

    }
}
