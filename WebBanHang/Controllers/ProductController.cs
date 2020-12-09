using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
using System.Data.Entity;
namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        SaleStoreDB db = new SaleStoreDB();
        // GET: Product
        public ActionResult Index(int ?CatID,String SupID, int ?page)
        {
            //var dsProduct = db.Products.Where(x => x.CategoryId == CatID).ToList();
            //ViewBag.TieuDe = db.Categories.Find(CatID).Name;
            List<Product> dsProduct;
            if(CatID!=null)
            {
                dsProduct = db.Products.Where(x => x.CategoryId == CatID).ToList();
                ViewBag.TieuDe = db.Categories.Find(CatID).Name;
                
            }
            else if(SupID!=null)
            {
                dsProduct = db.Products.Where(x => x.SupplierId.Equals(SupID)).ToList();
                ViewBag.TieuDe = db.Suppliers.Find(SupID).Name;
            }
            else
            {
                dsProduct = db.Products.ToList();
                ViewBag.TieuDe = "Danh Sách sản phẩm";
            }
            int pageSize = 6;
            int  pageNumber = page ?? 1;
            ViewBag.CatID = CatID;
            ViewBag.SupID = SupID;
            return View(dsProduct.ToPagedList(pageNumber, pageSize));
           
        }
        public ActionResult search(int? page, string name = "")
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;
            List<Product> products = null;
            if (name == "")
            {
                products = db.Products.Include(p => p.Category).Include(p => p.Supplier).OrderBy(x => x.Name).ToList();
            }
            
            else
                products = db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(y => y.Name.Contains(name)).OrderBy(z => z.Name).ToList();
            ViewBag.name = name;
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(int ProID = 101)
        {
            var p = db.Products.Find(ProID);
            if (p == null)
                return HttpNotFound();
            return View(p);
        }
    }
}