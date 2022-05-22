using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Common
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public int productPrice { get; set; }
        public int quantityAvailable { get; set; }
    }
}