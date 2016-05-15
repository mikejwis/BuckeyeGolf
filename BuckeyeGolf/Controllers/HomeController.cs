using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Note, can probably change this now to return the view so that the url is prettier
            return Redirect("/Index.html");
        }
    }
}
