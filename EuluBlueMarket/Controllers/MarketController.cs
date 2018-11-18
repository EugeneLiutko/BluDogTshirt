using EuluBlueMarket.Models;
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
            Console.WriteLine("N1");
            if (upload != null)
            {
                Console.WriteLine("N2");
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            Console.WriteLine("N3");
            return View("MainPage");
        }
        public ActionResult Main()
        {
            return View("MainPage");
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