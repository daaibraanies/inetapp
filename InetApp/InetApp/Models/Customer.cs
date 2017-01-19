using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserId { get; set; }
        public string Card_Number { get; set; }
    }
}