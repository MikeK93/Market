using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Market.Model.Entities;

namespace Market.Controllers
{
    public class UserController : Controller
    {
        // Login
        // GET: /User/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Login
        // POST: /User/

        [HttpPost]
        public ActionResult Index(Market.Model.Entities.User user)
        {
            user = Market.Model.Entities.User.GetByLoginPassword(user.Login, user.Password);

            Customer model = Customer.GetCustomerByUser(user);
            if (model != null)
                return RedirectToAction("Index", "Customer", new { cId = model.ID.ToString() });

            return View(user);
        }
    }
}
