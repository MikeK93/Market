using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Client.Test
{
    [TestClass]
    public class MerchandiseCategoryTest
    {
        [TestMethod]
        public void MerchadniseCategoryMethodSave_RestoredItemNotNull()
        {
            var m = new Market.Model.Entities.Merchandise(Guid.Parse("2ADF0FC9-3733-4A57-816C-04F854FFCC68"), Guid.Parse("e229e836-3b70-4afc-81ed-d24e89a380f7"));

            var newMC = new Market.Model.Entities.MerchandiseCategory(m.ID, Guid.Parse("C79C19E5-8BFE-470C-A79A-2463B924C27F"));
            newMC.Save();

            Assert.IsTrue(Market.Model.MarketProxy.Proxy.GetData("MerchandiseCategory",Middleware.MethodType.GetById, string.Empty, newMC.ID).Count != 0);
        }
    }
}
