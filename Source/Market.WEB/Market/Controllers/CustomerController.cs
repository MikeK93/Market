using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;
using Market.Models.ViewModel;

namespace Market.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Index(string cId, string userName)
        {
            Customer model = null;
            if (!string.IsNullOrEmpty(cId))
                model = Customer.GetById(Guid.Parse(cId));
            else
                model = Customer.GetCustomerByUserName(userName);

            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Save(Customer c)
        {
            var model = Customer.GetById(Guid.Parse(c.IDString));
            model.FirstName = c.FirstName;
            model.MiddaleName = c.MiddaleName;
            model.LastName = c.LastName;
            model.Email = c.Email;
            model.PhoneNumber = c.PhoneNumber;
            try { model.Save(); }
            catch (Exception e) { return Content(e.Message); }
            return RedirectToAction("Index", new { cId = c.IDString });
        }

        [HttpGet]
        public ActionResult MarketMap(string cId)
        {
            var allAvailableSpots = Spot.GetAllAvailableSpots;

            var model = new MarketMapVM(cId, allAvailableSpots);
            return View(model);
        }

        [HttpGet]
        public ActionResult ListOfMerhcandise(string cId, string filters)
        {
            var allSpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));
            var neededSpotSDMs = new List<SpotSDM>();

            var model = new ListOfMerchandiseVM(cId, neededSpotSDMs);
            return View(model);
        }

        [HttpGet]
        public ActionResult SelectedItems(Guid cId)
        {
            var customer = Customer.GetById(cId);
            return View(customer);
        }

        [HttpPost]
        public JsonResult DeleteCSI(string csiId)
        {
            var csi = CustomerSelectedItems.GetById(csiId);
            try
            {
                var countBefore = csi.Customer.CSIs.Count;
                csi.Delete();
                var countAfter = csi.Customer.CSIs.Count;
                return Json(new { msg = "Удалено успешно!", count = countAfter, sum = csi.Customer.CSIsSum });
            }
            catch (Exception e)
            { return Json(e.Message); }
        }

        public JsonResult SetStateCSI(string csiId)
        {
            var csi = CustomerSelectedItems.GetById(csiId);
            csi.IsSubmited = !csi.IsSubmited;
            try
            {
                csi.Save();
                return Json(csi.IsSubmited);
            }
            catch (Exception e) { return Json(e.Message); }
        }

        [HttpPost]
        public ActionResult GetStore(string sId)
        {
            var model = Spot.GetById(sId);
            if (model != null)
                return PartialView("_Spot", model);

            return Content("Error while loading!");
        }

        [HttpPost]
        public ActionResult AddMerchandise(string cId, string sdmId)
        {
            var c = Customer.GetById(Guid.Parse(cId));
            var isNew = c.CSIs.FindAll(_csi => _csi.SDMID.ToString() == sdmId).Count == 0;
            if (!isNew)
                return Json(new { added = false });

            c.CSIs.Add(new CustomerSelectedItems(Guid.Parse(cId), Guid.Parse(sdmId)));
            c.Save();
            return Json(new { added = true, count = c.CSIs.Count });
        }
    }
}