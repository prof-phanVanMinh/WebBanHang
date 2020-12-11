using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        SaleStoreDB db = new SaleStoreDB();
        public ActionResult Index(int ?page)
        {
            //Lấy 10 sản phẩm mới nhất
            var dsSanPhamMoi = db.Products.OrderByDescending(s => s.ProductId).Take(10).ToList();
            int pageSize = 6;
            int pageNumber = page ?? 1;
            return View(dsSanPhamMoi.ToPagedList(pageNumber,pageSize));
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}