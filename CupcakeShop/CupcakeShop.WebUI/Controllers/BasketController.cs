using CupcakeShop.Core.Contracts;
using CupcakeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CupcakeShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IOrderService orderService;
        public BasketController(IBasketService BasketService, IOrderService OrderService)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);
            //String redirect = this.HttpContext.Request["redirect"];
            //if (redirect != null)
            //{
            //    if (redirect == "Home/ProductListing")
            //    {
            //        return RedirectToAction("ProductListing", "Home");
            //    } else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //} else
            //{
            //    return RedirectToAction("Index", "Home");

            //}
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult BasketItemDecrease(string Id)
        {
            basketService.BasketItemDecrease(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult BasketItemIncrease(string Id)
        {
            basketService.BasketItemIncrease(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }
        //checkout view(partial view), template: create, model class: Order(Cupcake.Core.Models)
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";

            //TODO: process payment...

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            //clear the basket
            basketService.ClearBasket(this.HttpContext);

            //And finally redirect the user to the thank you page with order id.
            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }
        //partial view for the thank you page. Template: Empty
        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}