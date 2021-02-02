using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Beauty
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }
    }
}