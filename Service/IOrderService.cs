﻿using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IOrderService
    {
		void CreateOrder(Orders order);
		List<OrderItemDTO> GetListOrderByUser(int customerID, int status);
		List<OrderItemDTO> GetAllOrder(int status);
		Orders GetOrderDetail(int customerID, int orderID);
        int[] GetOrderCount(int customerId);
		void ChangeStatus(int orderID, int status);
		void UpdateChef(int orderID, int chefID);
		void UpdateShipper(int orderID, int shipperID);
	}
}
