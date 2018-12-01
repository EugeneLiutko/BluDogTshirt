using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models
{
    public class MarketItemsContext : DbContext
    {
        public MarketItemsContext() : base("DefaultConnection2")
        {
            
        }
        public DbSet<MarketItem> Products { get; set; }
        
    }
}