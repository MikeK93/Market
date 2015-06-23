using System;
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
    public class ListOfMerchandiseController : Controller
    {
        //
        // GET: /ListOfMerchandise/

        public ActionResult Autocomplete(string term, string categories)
        {
            var allSpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));
            var model = allSpotSDMs
                .Where(ssdm => ssdm.SDM.Merchendise.Name.StartsWith(term, true, System.Globalization.CultureInfo.CurrentCulture))
                .Take(10)
                .Select(ssdm => new
                {
                    label = ssdm.SDM.Merchendise.Name
                });

            return Json(model.Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string cId, string searchTerm = null, string categories = null, int sortType = 0)
        {
            ListOfMerchandiseVM model = null;

            if (Request.IsAjaxRequest())
            {
                var allSpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

                var selectedSpotSDMs = new List<SpotSDM>();

                selectedSpotSDMs = (from ssdm in allSpotSDMs
                                    where ssdm.SDM.Merchendise.Categories.Any(c => categories.Contains(c.Name))
                                       && ssdm.SDM.Merchendise.Name.StartsWith(searchTerm, true, System.Globalization.CultureInfo.CurrentCulture)
                                    select ssdm).ToList();

                model = new ListOfMerchandiseVM(cId, selectedSpotSDMs);
                var res = new List<SpotSDM>();
                switch (sortType)
                {
                    case 0:
                        res = model.AvailableSpotSDMs.OrderBy(_ssdm => _ssdm.SDM.Cost).ToList();
                        break;
                    case 1:
                        res = model.AvailableSpotSDMs.OrderByDescending(_ssdm => _ssdm.SDM.Cost).ToList();
                        break;
                    case 2:
                        res = model.AvailableSpotSDMs.OrderBy(_ssdm => _ssdm.SDM.Merchendise.Name).ToList();
                        break;
                    case 3:
                        res = model.AvailableSpotSDMs.OrderByDescending(_ssdm => _ssdm.SDM.Merchendise.Name).ToList();
                        break;
                }
                return PartialView("_SpotSDMs", res);
            }

            model = new ListOfMerchandiseVM(cId, new List<SpotSDM>());
            return View(model);
        }

    }
}
