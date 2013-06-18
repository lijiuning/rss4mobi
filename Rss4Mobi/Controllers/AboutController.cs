using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapMvcSample.Controllers;

namespace Rss4Mobi.Controllers
{
    public class AboutController : BootstrapBaseController
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            return View();
        }

    }
}
