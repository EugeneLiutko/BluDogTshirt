using EuluBlueMarket.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EuluBlueMarket.Controllers
{
    public class MarketController : Controller
    {
        [HttpGet]
        public ActionResult AddLot()
        {
            Console.WriteLine("F");
            return View("AddLot");
        }
        [HttpPost]
        public ActionResult AddLot(MarketItem TempItem, HttpPostedFileBase upload)
        {
            string fileName = "";
            if (upload != null)
            {
                fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            else
            {
                fileName = "No_Image_Available.png";
            }


            using (MarketItemsContext db = new MarketItemsContext())
            {
                if (User.Identity.IsAuthenticated)
                {
                    string nummm = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Phone;
                    string uname = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).FirstName;
                    MarketItem item1 = new MarketItem { Name = TempItem.Name, Description = TempItem.Description, Photo = fileName, UserDetails = uname + " - " + nummm };
                    db.Products.Add(item1);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Main", "Market");
        }
        public ActionResult Main()
        {
            InfoForPageProductModel model = new InfoForPageProductModel();
            using (MarketItemsContext db = new MarketItemsContext())
            {
                model.ProductModels = db.Products.ToList();
                //List<MarketItem> Work = new List<MarketItem>();
               // Work = model.ProductModels.ToList();
                //Work.Reverse();
            }

            return View("Main", model);
        }
        public ActionResult Setting()
        {
            return View("Setting");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}