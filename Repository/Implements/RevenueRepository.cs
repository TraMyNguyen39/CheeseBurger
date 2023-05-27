using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CheeseBurger.Repository.Implements
{
	public class RevenueRepository : IRevenueRepository
	{
		private readonly CheeseBurgerContext context;
		public RevenueRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public int NumberOrder(DateTime fromDate, DateTime toDate)
		{
			var successOrder = context.Orders.Where(p => p.StatusOdr == 5).Select(p => p);
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return successOrder.Where(p => p.SaleDate >= fromDate && p.SaleDate <= toDate).Count();
			}
			return successOrder.Count();
		}

		public int NumberIOrder(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.ImportOrders
					.Where(p => p.DateIO >= fromDate && p.DateIO <= toDate).Count();
			}
			return context.ImportOrders.Count();
		}

		public float TotalFund(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.ImportOrders
					.Where(p => p.DateIO >= fromDate && p.DateIO <= toDate)
					.Sum(e => e.TMoneyIO);
			}
			return context.ImportOrders.Sum(e => e.TMoneyIO);
		}

		public float TotalIncome(DateTime fromDate, DateTime toDate)
		{
			var successOrder = context.Orders.Where(p => p.StatusOdr == 5).Select(p => p);
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return successOrder.Where(p => p.SaleDate >= fromDate && p.SaleDate <= toDate)
					.Sum(e => e.TotalMoney);
			}
			return successOrder.Sum(e => e.TotalMoney);
		}
		public List<Orders> GetOrdersRangeTime(DateTime fromDate, DateTime toDate)
		{
			var successOrder = context.Orders.Where(p => p.StatusOdr == 5).Select(p => p);
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return successOrder.Where(p => p.SaleDate >= fromDate && p.SaleDate <= toDate).OrderBy(p => p.SaleDate)
					.GroupBy(l => l.SaleDate.Date).Select(cl => new Orders
					{
						SaleDate = cl.Key,
						TotalMoney = cl.Sum(c => c.TotalMoney)
					}).ToList();
			}
			return successOrder.OrderBy(p => p.SaleDate).GroupBy(l => l.SaleDate.Date).Select(cl => new Orders
					{
						SaleDate = cl.Key,
						TotalMoney = cl.Sum(c => c.TotalMoney)
					}).ToList();
		}
		public List<ImportOrder> GetIOrdersRangeTime(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.ImportOrders
					.Where(p => p.DateIO >= fromDate && p.DateIO <= toDate).OrderBy(p => p.DateIO)
					.GroupBy(l => l.DateIO.Date).Select(cl => new ImportOrder
					{
						DateIO = cl.Key,
						TMoneyIO = cl.Sum(c => c.TMoneyIO)
					}).ToList();
			}
			return context.ImportOrders.OrderBy(p => p.DateIO).GroupBy(l => l.DateIO.Date).Select(cl => new ImportOrder
					{
						DateIO = cl.Key,
						TMoneyIO = cl.Sum(c => c.TMoneyIO)
					}).ToList();
		}
		public List<FoodRevenueDTO> GetFoodRangeTime(DateTime fromDate, DateTime toDate)
		{
			var successOrder = context.Orders.Where(p => p.StatusOdr == 5).Select(p => p);
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				successOrder = successOrder.Where(p => p.SaleDate >= fromDate && p.SaleDate <= toDate);
				var sOrder_Food = from c in successOrder
								  join a in context.Order_Foods on c.OrderID equals a.OrderID
								  select new { c, a };
				var tsOrder_Food = sOrder_Food.GroupBy(p => p.a.FoodID).Select(g => new
				{
					idFood = g.Key,
					cnt = g.Count()
				});
				tsOrder_Food = tsOrder_Food.OrderByDescending(p => p.cnt).Take(5);
				var res = from p in context.Foods
						  join q in tsOrder_Food on p.FoodID equals q.idFood
						  select new FoodRevenueDTO
						  {
							  IDFoodRevenue = p.FoodID,
							  NameFoodRevenue = p.FoodName,							  
							  ImgFoodRevenue = p.ImageFood,
							  CntFoodRevenue = q.cnt
						  };
				return res.ToList();
			}
			var sOrder_Food1 = from c in successOrder
							  join a in context.Order_Foods on c.OrderID equals a.OrderID
							  select new { c, a };
			var tsOrder_Food1 = sOrder_Food1.GroupBy(p => p.a.FoodID).Select(g => new
			{
				idFood = g.Key,
				cnt = g.Count()
			});
			tsOrder_Food1 = tsOrder_Food1.OrderByDescending(p => p.cnt).Take(5);
			var res1 = from p in context.Foods
					  join q in tsOrder_Food1 on p.FoodID equals q.idFood
					   select new FoodRevenueDTO
					   {
						   IDFoodRevenue = p.FoodID,
						   NameFoodRevenue = p.FoodName,
						   ImgFoodRevenue = p.ImageFood,
						   CntFoodRevenue = q.cnt
					   };
			return res1.ToList();
		}
		public List<CustomerRevenueDTO> GetCustomerRangeTime(DateTime fromDate, DateTime toDate)
		{
			var successOrder = context.Orders.Where(p => p.StatusOdr == 5).Select(p => p);
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				successOrder = successOrder.Where(p => p.SaleDate >= fromDate && p.SaleDate <= toDate);
				var tsuccessOrder = successOrder.GroupBy(o => o.CustomerID).Select(g => new
				{
					cusId = g.Key,
					TMoney = g.Sum(o => o.TotalMoney)
				}).OrderByDescending(g => g.TMoney).Take(5);
				var res = from p in context.Customers
						   join q in tsuccessOrder on p.CustomerID equals q.cusId
						   select new CustomerRevenueDTO
						   {
							   CusRevenueID = p.CustomerID,
							   CusRevenueName = p.CustomerName,
							   CusRevenueTMoney = q.TMoney,							 
						   };
				return res.ToList();
			}
			var tsuccessOrder1 = successOrder.GroupBy(o => o.CustomerID).Select(g => new
			{
				cusId = g.Key,
				TMoney = g.Sum(o => o.TotalMoney)
			}).OrderByDescending(g => g.TMoney).Take(5);
				var res1 = from p in context.Customers
						   join q in tsuccessOrder1 on p.CustomerID equals q.cusId
						   select new CustomerRevenueDTO
						   {
							   CusRevenueID = p.CustomerID,
							   CusRevenueName = p.CustomerName,
							   CusRevenueTMoney = q.TMoney,
						   };
			return res1.ToList();
		}
	}
}
