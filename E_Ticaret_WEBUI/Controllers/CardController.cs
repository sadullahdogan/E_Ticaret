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
        public ActionResult AddToCard(int Id, int? quentity,string returnUrl)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                if (quentity == null)
                    GetCard().AddProduct(product, 1);
                else
                    GetCard().AddProduct(product, Int32.Parse(quentity.ToString()));
            }
            if (returnUrl != null) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index");


        }
        public ActionResult Remove(int Id,string returnUrl)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }
            if (returnUrl != null) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index");
        }
        public Card GetCard()
        {
            if (Session["Card"] == null) {
                Session["Card"]= new Card();
            }
            var card = (Card)Session["Card"];
           

            return card;
        }
        [Authorize(Roles ="user")]
        public ActionResult Checkout() {
            return View(new ShippingDetails());
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shipping) {
            var cart = GetCard();
            if (cart.Cardlines.Count == 0) {
                ModelState.AddModelError("Product Not Found on Card", "Sepette ürün Yok");
            }
            if (ModelState.IsValid)
            {
                shipping.Username = User.Identity.Name;
                SaveOrder(cart, shipping);
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
        public PartialViewResult CardMenu() {
            return PartialView(GetCard());
        }
        private void SaveOrder( Card card,ShippingDetails shipping) {
            var order = new Order();
            order.OrderNumber = "A" + new Random().Next(11111, 99999).ToString();
            order.Total = card.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.Username = User.Identity.Name;
            order.Adres = shipping.Adres;
            order.AdresBilgi = shipping.AdresBilgi;
            order.Sehir = shipping.Sehir;
            order.Semt = shipping.Semt;
            order.Mahalle = shipping.Mahalle;
            order.PostaKodu = shipping.PostaKodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var item in card.Cardlines)
            {
                var orderLine = new OrderLine();
                orderLine.Quentity = item.Quentity;
                orderLine.Price = item.Quentity * item.Product.Price;
                orderLine.ProductId = item.Product.Id;
                order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        
    }
}