using ECommerceMVC.Dtos.Responses;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceMVC.Models
{

    public class CartItem
    {
        public ProductListResponse Product { get; set; }
        public int Piece { get; set; }
    }
    public class CartCollection
    {
        public List<CartItem> cartItems { get; set; } = new List<CartItem>();
        public void Add(CartItem cartItem) 
        {
            var finding = cartItems.Find(c => c.Product.Id == cartItem.Product.Id);
            if (finding == null)
            {
                cartItems.Add(cartItem);
            }
            else
            {
                finding.Piece += cartItem.Piece;
            }
        }
        public void ClearAll()=> cartItems.Clear();
        public double GetTotalPrice() => cartItems.Sum(c => c.Product.Price.Value * (1-c.Product.Discount.Value)* c.Piece);
        public void Delete(int id) => cartItems.RemoveAll(c => c.Product.Id == id);
    }
}
