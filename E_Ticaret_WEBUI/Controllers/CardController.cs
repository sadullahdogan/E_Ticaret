using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret_DAL.DB;
using E_Ticaret_DLL.Models;
using E_Ticaret_Entity.Entity;

namespace E_Ticaret_WEBUI.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(GetCard());
        }
        public ActionResult AddToCard(int Id, int? quentity)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                if (quentity == null)
                    GetCard().AddProduct(product, 1);
                else
                    GetCard().AddProduct(product, Int32.Parse(quentity.ToString()));
            }
            return RedirectToAction("Index");


        }
        public ActionResult Remove(int Id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Card GetCard()
        {
            var card = (Card)Session["Card"];
            if (card == null)
            {
                card = new Card();
                Session["Card"] = card;

            }

            return card;
        }
        public ActionResult Checkout() {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shipping) {
            var cart = GetCard();
            if (cart.Cardlines.Count == 0) {
                ModelState.AddModelError("Product Not Found on Card", "Sepette ürün Yok");
            }
            if (ModelState.IsValid)
            {
                shipping.Username = User.Identity.Name;
                cart.Clear();
                return RedirectToAction("Completed");
            }
            else {
                return View(shipping);
            }
            
        }
        public ActionResult Completed() {
            return View();
        }
        
    }
}