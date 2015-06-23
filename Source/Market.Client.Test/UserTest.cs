using System;
using Market.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Client.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void GetCustomerByUser_CustomerFirstNameMariaReturned()
        {
            User user = new User(new Guid("fe96c001-510c-40f1-bfa9-b61e390ab444"));
            Assert.AreEqual("Maria", Customer.GetCustomerByUser(user).FirstName);
        }
    }
}