using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using Rss4Mobi.Models;
using BootstrapMvcSample.Controllers;

namespace Rss4Mobi.Controllers
{

    public class HomeController : BootstrapBaseController
    {
        //
        // GET: /Home/
        private readonly Rss4MobiDBContext db = new Rss4MobiDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetCulture(string language)
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(
                new HttpCookie("Culture", language)
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddYears(100)
                }
                );
            if (HttpContext.Request.UrlReferrer != null)
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            else
                return RedirectToAction("Index");
   
        }
    }
}
