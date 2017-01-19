using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetApp.Models
{
    public class Depot
    {
        public int Id { get; set; }
        public string Good_Name { get; set; }
        public string Provider_Name { get; set; }
        public int  Depot_Quantity { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Good_id { get; set; }


        
    }
}