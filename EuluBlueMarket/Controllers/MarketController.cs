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
            return View("AddLot");
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

        public ActionResult Ha()
        {
            return View("Hahaha");
        }

        [HttpPost]
        public ActionResult AddLot(MarketItem TempItem)
        {
            ViewBag.Yes = "Yes";
            return View("AddLot");
        }

        [HttpPost]
        public async void Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            //return RedirectToAction("Main");
        }
    }
}