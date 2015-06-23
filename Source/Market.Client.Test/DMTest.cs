using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Client.Test
{
    [TestClass]
    public class DMTest
    {
        [TestMethod]
        public void SaveNewDM_IsNewEqualsFalse()
        { 
            var dm = new DM(new Guid("2b5696fd-5701-401b-a5f1-0ff9427c6b87"), new Guid("ce00bbe1-b3ef-4b2f-b085-9374e7fdb8c2"));
            var dfn = dm.Dealer.FirstName;
            dm.Save();
            Assert.IsTrue(!dm.IsNew);
            dm.Delete();
        }
    }
}