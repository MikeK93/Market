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
    public class MarketMapVM
    {
        public MarketMapVM() { }

        public MarketMapVM(string customerId, IList<Spot> availableSpots)
        {
            CustomerId = customerId;
            AvailableSpots = availableSpots;
            this.Customer = CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetById, string.Empty, Guid.Parse(CustomerId))[0]); 
        }

        public string CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public IList<Spot> AvailableSpots { get; private set; }
    }
}
