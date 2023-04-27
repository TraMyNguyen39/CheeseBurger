using CheeseBurger.Model;

namespace CheeseBurger.Repository.Implements
{
    public class CustomerRespository : ICustomerRespository
    {
        private readonly CheeseBurgerContext context;
        public CustomerRespository (CheeseBurgerContext context)
        {
            this.context = context;
        }

		public int GetCustomerID(int accountID)
		{
			var customer = context.Customers.Where(p => p.AccountID == accountID).Select(p => p).FirstOrDefault();
            return customer != null ? customer.CustomerID : 0;
		}
	}
}
