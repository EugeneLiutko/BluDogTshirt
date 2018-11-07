using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name{ get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        List<MarketItem> lots { get; set; }
        public ApplicationUser()
        {
        }
    }
}