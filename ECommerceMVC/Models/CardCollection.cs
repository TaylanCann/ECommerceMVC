using ECommerceMVC.Dtos.Responses;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceMVC.Models
{

    public class CardItem
    {
        public ProductListResponse Product { get; set; }
        public int Piece { get; set; }
    }
    public class CardCollection
    {
        public List<CardItem> cardItems { get; set; } = new List<CardItem>();
        public void Add(CardItem cardItem) 
        {
            var finding = cardItems.Find(c => c.Product.Id == cardItem.Product.Id);
            if (finding == null)
            {
                cardItems.Add(cardItem);
            }
            else
            {
                finding.Piece += cardItem.Piece;
            }
        }
        public void ClearAll()=>cardItems.Clear();
        public double GetTotalPrice() => cardItems.Sum(c => c.Product.Price.Value * (1-c.Product.Discount.Value)* c.Piece);
        public void Delete(int id) => cardItems.RemoveAll(c => c.Product.Id == id);
    }
}
