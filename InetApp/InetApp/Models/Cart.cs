using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;

namespace InetApp.Models
{
    public class Cart
    {
        private List<Pur_strings> cartLines = new List<Pur_strings>();
        private StockContext db = new StockContext();

        public Cart()
        {

        }
        
        public void AddItem(Depot item, int quantity=1)
        {
            Pur_strings line = cartLines
                .Where(x => x.Gd_id == item.Id)
                .FirstOrDefault();

            if (line == null)
            {
                cartLines.Add(new Pur_strings
                {
                    Gd_id=item.Id,
                    Quantity = quantity,
                    Cost=item.Price*quantity,
                    Good = item
                });
            }
            else
            {
                line.Quantity = quantity;
                line.Cost = item.Price * quantity;
            }
        }
        public void RemoveItem(Depot item)
        {
            cartLines.RemoveAll(l => l.Gd_id == item.Id);
            if (cartLines.Count == 0)
            {
                HttpContext.Current.Session["Cart"] = null;
            }
        }

        public double TotalCost()
        {
            return cartLines.Sum(p => p.Cost);
        }

        public void Clear()
        {
            cartLines.Clear();
        }

        public IEnumerable<Pur_strings> Lines
        {
            get { return cartLines; }
        }

    }
}