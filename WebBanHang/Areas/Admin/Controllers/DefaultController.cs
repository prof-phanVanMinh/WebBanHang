using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        SaleStoreDB db = new SaleStoreDB();
        // GET: Admin/Default
        public ActionResult Index()
        {
            ViewBag.Product_Count = db.Products.Count();
            ViewBag.Orders = db.Orders.Count();
            ViewBag.Customers = db.Customers.Count();
            
            return View();
        }
    }
}