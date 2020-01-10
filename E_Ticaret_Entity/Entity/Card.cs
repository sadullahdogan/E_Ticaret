using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Entity.Entity
{
    public class Card
    {
        private List<Cardline> _cardLiens = new List<Cardline>();
        public List<Cardline> Cardlines
        {
            get { return  _cardLiens; } 
        }
        public void AddProduct(Product product, int Quentity) {
            var line = _cardLiens.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line != null)
            {
                line.Quentity+=Quentity;
            }
            else {
                _cardLiens.Add(new Cardline() { Product = product, Quentity = Quentity });
            }
        }
        public void DeleteProduct(Product product) {
            var cardline = _cardLiens.FirstOrDefault(x => x.Product.Id == product.Id);

            if (cardline.Quentity > 1)
            {
                cardline.Quentity--;

            }
            else {
                _cardLiens.Remove(cardline);
            }
        }
        public double TotalPrice() {
            return _cardLiens.Sum(x => x.Quentity * x.Product.Price);
        }
        public void Clear()
        {
            _cardLiens.Clear();
        }
    }
    public class Cardline
    {
        public Product Product { get; set; }
        public int Quentity { get; set; }
    }
}
