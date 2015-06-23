using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.Models.ViewModel
{
    public class ListOfMerchandiseVM
    {
        public ListOfMerchandiseVM() { }

        public ListOfMerchandiseVM(string customerId, IList<SpotSDM> availableSpotSDMs)
        {
            CustomerId = customerId;
            AvailableSpotSDMs = availableSpotSDMs;
            this.Customer = CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetById, string.Empty, Guid.Parse(CustomerId))[0]);
            this.Categories = (from category in CategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Category", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty))
                              select category.Name).ToList();
        }

        public string CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public IList<SpotSDM> AvailableSpotSDMs { get; private set; }

        public IList<string> Categories { get; private set; }
    }
}