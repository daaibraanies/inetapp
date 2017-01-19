using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InetApp.Models;
using System.Collections;

namespace InetApp.Controllers
{
    public class StockController : Controller
    {
        private StockContext db = new StockContext();

        public ActionResult Home()
        {
            ViewBag.Goods = db.Goods;
            return View();
        }

        public ActionResult Search(string searchTerm)
        {
            ViewBag.Goods = db.Goods;
            if (String.IsNullOrEmpty(searchTerm)) return Redirect("~/");
            var result = db.Depots.Where(w => w.Good_Name.Contains(searchTerm)).ToList();

            return View("Good", result);
        }

        //All goods
        public ActionResult Index()
        {
            ViewBag.Goods = db.Goods;
            return View(db.Depots);
        }

        //Вывод выбранного товара
        public ActionResult Good(int? goodId,int? Id,string Provider="",string Category="",string returnUrl="")
        {
            ViewBag.Goods = db.Goods;
            int argMask = 0 ;
            List<Depot> selectedItems = new List<Depot>();

            if (Id.HasValue)
            {
                try
                { 
                   selectedItems = db.Depots.Where(x => x.Id == Id).ToList();
                   return View(selectedItems);

                }
                catch (Exception e)
                {
                    return RedirectToAction("Error");
                }
            }
            else if (goodId.HasValue) argMask += 100;
            else if (!String.IsNullOrEmpty(Provider)) argMask += 10;
            else if (!String.IsNullOrEmpty(Category)) argMask += 1;

            try
            {
                switch (argMask)
                {
                    case 111:
                        selectedItems = db.Depots.Where(x => x.Good_id == goodId)
                           .Where(x => x.Category == Category)
                           .Where(x => x.Provider_Name == Provider)
                           .Where(x => x.Depot_Quantity > 0)
                           .ToList();
                        break;
                    case 110:
                        selectedItems = db.Depots.Where(x => x.Good_id == goodId)
                           .Where(x => x.Category == Category)
                           .Where(x => x.Depot_Quantity > 0)
                           .ToList();
                        break;
                    case 101:
                        selectedItems = db.Depots.Where(x => x.Good_id == goodId)
                           .Where(x => x.Provider_Name == Provider)
                           .Where(x => x.Depot_Quantity > 0)
                           .ToList();
                        break;
                    case 100:
                        selectedItems = db.Depots.Where(x => x.Good_id == goodId)
                            .Where(x => x.Depot_Quantity > 0)
                            .ToList();
                        break;
                    case 11:
                        selectedItems = db.Depots.Where(x => x.Category == Category)
                            .Where(x => x.Provider_Name == Provider)
                            .Where(x => x.Depot_Quantity > 0)
                            .ToList();
                        break;
                    case 10:
                        selectedItems = db.Depots.Where(x => x.Provider_Name == Provider)
                             .Where(x => x.Depot_Quantity > 0)
                             .ToList();
                        break;
                    case 1:
                        selectedItems = db.Depots.Where(x => x.Category == Category)
                              .Where(x => x.Depot_Quantity > 0)
                              .ToList();
                        break;
                    default:
                        selectedItems = db.Depots.ToList();
                        break;
                }
                if (selectedItems.Count == 0) 
                {
                    return RedirectToAction("Index");
                }
                return View(selectedItems);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Error()
        {
            ViewBag.Goods = db.Goods;
            return View();
        }

    }
}
