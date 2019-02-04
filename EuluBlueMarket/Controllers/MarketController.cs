using EuluBlueMarket.Models;
using EuluBlueMarket.Models.MarketModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


            using (ApplicationContext db = new ApplicationContext())
            {
                if (User.Identity.IsAuthenticated)
                {
                    string nummm = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Phone;
                    string uname = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).FirstName;
                    string UID = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Email;
                    MarketItem item1 = new MarketItem { Name = TempItem.Name, Description = TempItem.Description, Photo = fileName, Price = TempItem.Price, UserID = UID, UserDetails = uname + " - " + nummm };
                    db.Products.Add(item1);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Main", "Market");
        }

        [HttpGet]
        public ActionResult Exchange()
        {
            InfoForPageProductModel model = new InfoForPageProductModel();
            using (ApplicationContext db = new ApplicationContext())
            {
                model.ProductModels = db.Products.ToList();
                //select curent
                //select products by price in dpodown
                return View("Exchange", model);
            }
        }

        [HttpPost]
        public ActionResult Exchange(FinalItem TempItem)
        {
            MailAddress from = new MailAddress("Eulutest@gmail.com", "Eulu-Interchange");
            //MailAddress to = new MailAddress(TempItem.userinfo); 
            MailAddress to = new MailAddress("Lev01b27@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Новий обмін";
            m.Body = "<h2>Вам запропонували обінятися</h2><br><p> Чи ви бажаєте обміняти " + TempItem.OldName + " на " + TempItem.NewName+" - "+ TempItem.NewPrice+" грн" + "</p>"; // <a />
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("Eulutest@gmail.com", "Strongpassword");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return RedirectToAction("Main", "Market");
        }

        public ActionResult Main()
        {
            InfoForPageProductModel model = new InfoForPageProductModel();
            using (ApplicationContext db = new ApplicationContext())
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