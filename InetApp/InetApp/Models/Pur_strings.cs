using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetApp.Models
{
    public class Pur_strings
    {
        public Pur_strings()
        {

        }

       public Pur_strings(Pur_strings str)
        {
            this.Id = str.Id;
            this.Pur_id = str.Pur_id;
            this.Gd_id = str.Gd_id;
            this.Good = str.Good;
            this.Quantity = str.Quantity;
            this.Cost = str.Cost;
        }

        public int Id { get; set; }
        public int Pur_id { get; set; }
        public int Gd_id { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public Depot Good { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}