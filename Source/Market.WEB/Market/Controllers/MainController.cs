using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salesperson()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Dealer()
        {
            return View();
        }
    }
}