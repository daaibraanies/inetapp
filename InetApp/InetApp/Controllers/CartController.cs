using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using InetApp.Models;

namespace InetApp.Controllers
{
    public class CartController : Controller
    {
        private IEnumerable<Depot> repository;
        private StockContext db = new StockContext();
        

        public ActionResult Index()
        {
            ViewBag.Goods = db.Goods;
            Cart cart = (Cart)HttpContext.Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("Index","Stock");
            }
            return View(cart);
        }

        public CartController()
        {
            repository = db.Depots;
        }

        public CartController(IEnumerable<Depot> repo)
        {
            repository = repo;
        }

        //Add to cart item
        public ActionResult AddToCart(int goodId, string returnUrl, int qnt = 1)
        {
            Depot product = repository.FirstOrDefault(p => p.Id == goodId);
            if (product != null)
            {
                GetCart().AddItem(product, qnt);
            }
            if (returnUrl == "/Stock/Good/"+goodId) return Redirect("~/Cart/Index");
            else
            {
                return Redirect(returnUrl);
            }
        }

        public ActionResult RemoveFromCart(int goodId,string returnUrl)
        {
            Depot product = repository.FirstOrDefault(p => p.Id == goodId);
            if (product != null)
            {
                GetCart().RemoveItem(product);
            }
            return Redirect(returnUrl);
        }

        public ActionResult GetPurchase(int cst)
        {
            if (cst!=null)
            {
                Cart cart = (Cart)Session["Cart"];
                Purchase pur = new Purchase();
                
                pur.Customer_Id = cst;
                pur.Item_number = cart.Lines.Count();
                pur.Overall_cost = cart.TotalCost();
                pur.Purchase_Date = DateTime.Now;

                db.Purchases.Add(pur);
                db.SaveChanges();
                int lastPur = db.Purchases.GroupBy(x=>x.Id).Count();

                foreach (Pur_strings str in cart.Lines)
                {
                    str.Good = null;
                    Pur_strings psr = new Pur_strings();
                    psr.Gd_id = str.Gd_id;
                    psr.Cost = str.Cost;
                    psr.Pur_id = lastPur;
                    psr.Quantity = str.Quantity;
                   

                    db.Pur_stringss.Add(psr);
                    db.SaveChanges();
                }

                cart.Clear();
                Session["Cart"] = null;

                ViewBag.Goods = db.Goods;
                ViewBag.prId = lastPur;
                return View();
            }
            return RedirectToAction("Index", "Stock");
        }


        public ActionResult RemoveAll()
        {
            Cart cart = GetCart();
            cart.Clear();
            Session["Cart"] = null;
            return RedirectToAction("Index","Stock");
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

    }
}
