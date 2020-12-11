using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; }//Create property Items only get for class Cart
        public Cart()
        {
            Items = new List<CartItem>();//initial Items
        }
        //Method add a CartItem to List<CartItem>
        public void AddItem(Product p, int quantity)
        {
            CartItem item =Items.Find(x => x.Product.ProductId == p.ProductId);
            if (item == null)//neu chua ton tai cartItem co productID nay
            {
                Items.Add(new CartItem { Product = p, Quantity = quantity });//tien hanh them mot CartItem vao gio hang 
               
            }
            else//da ton tai CartItem voi productID nay
                item.Quantity += quantity; 
        }
        //Ham cap nhap so luong cua san pham trong gio
        public void UpdateItem(Product p, int quantity)
        {
            CartItem item = Items.Find(x => x.Product.ProductId == p.ProductId);
            if(item!=null)
            {
                if (quantity > 0)
                    item.Quantity = quantity;
                else
                    Items.Remove(item);
            }
            //Hàm xóa 1 sản phẩm khỏi giỏ hàng
        }
        public void DeleteItem(Product p)
        {
            CartItem item = Items.Find(x => x.Product.ProductId == p.ProductId);
            if (item != null)
                Items.Remove(item);
        }
        //Bổ sung thuộc tính SubTotal cho lớp Cart để tính tỏng thành tiền
        public double SubTotal
        {
            get
            {
                double sum = 0;
                foreach (var item in Items)
                {
                    sum += item.Total;
                }
                //Cách 2: dùng Method Syntax
                //sum = Items.Sum(x => x.Total);
                return sum;
            }
        }
    }
    public class CartItem
    {
        public Product Product{ get; set; }
        public int Quantity { get; set; }
        public double Total { get { return Product.UnitPrice * Quantity; } }

    }
}