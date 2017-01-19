using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InetApp.Models;
using System.Data.Entity;

namespace InetApp.Controllers
{
    public class CustomerController : Controller
    {
        private StockContext db = new StockContext();

        public ActionResult Index()
        {
            ViewBag.Goods = db.Goods;
            return View();
        }

        public ActionResult GetCheck(int? purchaseId)
        {
            ViewBag.Goods = db.Goods;
            if (!purchaseId.HasValue)
            {
                return Redirect("~/Stock/Error");
            }

            var check = (from p in db.Pur_stringss where (p.Pur_id == purchaseId) select p);
            check.ToList();                   
                
                return View(check);            
        }

        public ActionResult GetPayed(string name,string surname,string cc)
        {
            if(!String.IsNullOrEmpty(name) &&
               !String.IsNullOrEmpty(surname) &&
                !String.IsNullOrEmpty(cc))
            {
                Customer customer = new Customer();
                
                customer.Name = name;
                customer.Surname = surname;
                customer.UserId = 1;
                customer.Card_Number = cc;

                db.Customers.Add(customer); 
                db.SaveChanges();
                int lastCustomer = db.Customers.GroupBy(x => x.Id).Count();
                string url = "cst=" + lastCustomer.ToString();

                return Redirect("~/Cart/GetPurchase?" + url);
            }
            else
            {
                return RedirectToAction("Index", "Good");
            }
            
        }

    }
}
