using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public List<MarketItem> Lots;
    }
}