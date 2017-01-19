using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetApp.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public System.DateTime Purchase_Date { get; set; }
        public double Overall_cost { get; set; }
        public int Item_number { get; set; }
        public int Customer_Id { get; set; }

        public virtual ICollection<Pur_strings> Pur_strings { get; set; }
    }
}