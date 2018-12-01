using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models
{
    public class MarketContext: DbContext
    {
        public MarketContext()
            : base("DbConnection")
        {
            //Items = new List<MarketItem>
        }

        public DbSet<MarketItem> Items { get; set; }
    }
}