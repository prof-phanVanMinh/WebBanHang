using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        SaleStoreDB db = new SaleStoreDB();
        // GET: ShoppingCart
        public ActionResult AddToCart(int ProID)
        {
            
            Cart cart = GetCart();
            Product p = db.Products.Find(ProID);
            //Gọi hàm thêm sản phầm từ lớp Cart của Namespace Models;
            cart.AddItem(p, 1);
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            Cart cart = GetCart();
            return View(cart);
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["CART"];
            if(cart==null)
            {
                cart = new Cart();
                Session["CART"] = cart;
            }
            return cart;
        }
        public ActionResult UpdateCart(int[] ProID, int[] Quantity)
        {
            //lấy giỏ hàng từ Session
            Cart cart = GetCart();
            //duyet qua cac ma san pham trong mang
            for (int i = 0; i < ProID.Length; i++)
            {
                //truy van thong tin san pham them ma san pham
                Product p = db.Products.Find(ProID[i]);
                //goi ham cap nhat so luong cho san pham tuong ung
                cart.UpdateItem(p, Quantity[i]);
            }
            return RedirectToAction("ViewCart");
        }
        public ActionResult DeleteCart(int[] ProID)
        {
            //lấy giỏ hàng từ Session
            Cart cart = GetCart();
            //duyet qua cac ma san pham trong mang
            for (int i = 0; i < ProID.Length; i++)
            {
                //truy van thong tin san pham them ma san pham
                Product p = db.Products.Find(ProID[i]);
                //goi ham cap nhat so luong cho san pham tuong ung
                cart.DeleteItem(p);
            }
            return RedirectToAction("ViewCart");
        }
    }
}