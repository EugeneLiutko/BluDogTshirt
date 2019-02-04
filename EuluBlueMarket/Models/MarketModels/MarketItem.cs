using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models
{
    public class MarketItem
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string UserDetails { get; set; }
        public int Price { get; set; }
        public string UserID { get; set; }
    }
}