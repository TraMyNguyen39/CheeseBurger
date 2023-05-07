using CheeseBurger.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheeseBurger.Model
{
    public class CheeseBurgerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Food_Ingredients> Food_Ingredients { get; set; }
        public DbSet<ImportOrder> ImportOrders { get; set; }
        public DbSet<ImportOrders_Ingredients> ImportOrders_Ingredients { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Order_Food> Order_Foods { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
		public DbSet<Revenues> Revenues { get; set; }

		public CheeseBurgerContext(DbContextOptions<CheeseBurgerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
           .HasKey(c => new { c.CustomerID, c.FoodID });

            modelBuilder.Entity<Food_Ingredients>()
                .HasKey(fi => new { fi.FoodID, fi.IngredientsId });

            modelBuilder.Entity<Order_Food>()
                .HasKey(of => new { of.OrderID, of.FoodID });

            modelBuilder.Entity<Orders>()
                .HasOne(e => e.Customer)
                .WithMany()
                .HasForeignKey(e => e.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasOne(e => e.Ward)
                .WithMany()
                .HasForeignKey(e => e.WardID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Revenues>()
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
