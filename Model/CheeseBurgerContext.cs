using CheeseBurgerWeb.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheeseBurgerWeb.Model
{
    public class CheeseBurgerContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public CheeseBurgerContext(DbContextOptions<CheeseBurgerContext> options) : base(options) 
        { 
        }
    }
}
