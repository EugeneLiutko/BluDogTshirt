using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuluBlueMarket.Models.MarketModels
{
    public class FinalItem
    {
        public string OldId { get; set; }
        public string OldUser { get; set; }
        public string OldUserId { get; set; }
        public int OldPrice { get; set; }
        public string OldName { get; set; }
        public string OldPhoto { get; set; }

        public string NewId { get; set; }
        public string NewUser { get; set; }
        public string NewUserId { get; set; }
        public int NewPrice { get; set; }
        public string NewName { get; set; }
        public string NewPhoto { get; set; }
    }
}