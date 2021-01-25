using CupcakeShop.Core.Contracts;
using CupcakeShop.Core.Models;
using CupcakeShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CupcakeShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }


        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "About our Capcake Shop";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You like our Cupcakes and you want to contact us!";

            return View();
        }
        public ActionResult Catering()
        {
            ViewBag.Message = "Capcake Caterings";

            return View();
        }

        public ActionResult DietAll()
        {
            ViewBag.Message = "Dietary & Allergen";

            return View();
        }
        public ActionResult Careers()
        {
            ViewBag.Message = "Capcake Careers";

            return View();
        }
        public ActionResult PrivPol()
        {
            ViewBag.Message = "Privacy Policy";

            return View();
        }
        public ActionResult TermsCon()
        {
            ViewBag.Message = "Terms & Conditions";

            return View();
        }
        public ActionResult ProductListing(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            return View(model);
        }
    }
}