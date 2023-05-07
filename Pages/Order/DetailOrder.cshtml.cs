﻿using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CheeseBurger.Pages.Order
{
    public class DetailOrderModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IOrder_FoodService order_FoodService;
        private readonly IWardService wardService;
        private readonly IDistrictService districtService;
        private readonly IStaffService staffService;
        private readonly ICartService cartService;
        public Orders order { get; set; }
        public string address { get; set; }
        public StaffOrderDTO chef { get; set; }
        public StaffOrderDTO shipper { get; set; }
        public List<LineItemDTO> lineItems { get; set; }
        [BindProperty(SupportsGet = true)]
        public int orderId { get; set; }
        public DetailOrderModel(IOrderService orderService, IOrder_FoodService order_FoodService, ICartService cartService,
            IWardService wardService, IDistrictService districtService, IStaffService staffService)
        {
            this.orderService = orderService;
            this.order_FoodService = order_FoodService;
            this.cartService = cartService;
            this.wardService = wardService;
            this.districtService = districtService;
            this.staffService = staffService;
        }
        public IActionResult OnGet()
        {
            order = orderService.GetOrderDetail(0, orderId);
            if (order != null)
            {
                var wrd = wardService.GetWard(order.WardID);
                var dis = districtService.GetDistrict(wrd.DistrictID);
                address = order.HourseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";

                chef = order.ChefID != null ? staffService.GetStaffOrder((int)order.ChefID) : null;
                shipper = order.ShipperID != null ? staffService.GetStaffOrder((int)order.ShipperID) : null;
                lineItems = order_FoodService.GetAllLine(orderId);
                return Page();
            }
            return RedirectToPage("/Error");
        }
        public IActionResult OnPostCancel()
        {
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.canceled);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
        public IActionResult OnPostConfirm()
        {
            var staffID = HttpContext.Session.GetInt32("staffID");
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.preparing);
            orderService.UpdateChef(orderId, (int)staffID);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
        public IActionResult OnPostPrepareDone()
        {
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.prepareDone);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
        public IActionResult OnPostConfirmShipping()
        {
            var staffID = HttpContext.Session.GetInt32("staffID");
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.shipping);
            orderService.UpdateShipper(orderId, (int)staffID);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
        public IActionResult OnPostSuccess()
        {
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.completed);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
        public IActionResult OnPostFailed()
        {
            orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.closed);
            return RedirectToPage("/Order/DetailOrder", new { orderId });
        }
    }
}