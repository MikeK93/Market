using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Client.Test
{
    [TestClass]
    public class MerchandiseTest
    {
        [TestMethod]
        public void IsNewMerchandiseSavingToDB()
        {
            Merchandise newM = new Merchandise() { Name = "Test", Cost = 100500 };
            newM.Save();

            Assert.IsNotNull(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetByQuery, "Name = 'Test'", Guid.Empty));
        }

        [TestMethod]
        public void IsCreatedMerhcadiseCanBeDeletedFromDB()
        {
            var m = Market.Model.Mappers.MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetByQuery, "Name = 'Test'", Guid.Empty)[0]);
            m.Delete();
            var s = MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetByQuery, "Name = 'Test'", Guid.Empty);
            Assert.IsTrue(s.Count == 0);
        }
    }
}
