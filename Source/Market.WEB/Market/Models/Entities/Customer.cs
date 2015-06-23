// --------------------------------------------------------------------------
// <copyright file="Customer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;
using Market.Middleware;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class represents a Customer.
    /// </summary>
    public class Customer
    {
        private Guid _id;

        private Guid _uId;

        private bool _isNew;

        private int _selectedItemsCount = 0;

        /// <summary>
        /// Default ctor.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Ctor for creating new customer.
        /// </summary>
        /// <param name="userId">User's id attached to current customer.</param>
        public Customer(Guid userId)
        {
            _isNew = true;
            _id = Guid.NewGuid();
            IDString = _id.ToString();
            _uId = userId;
            UserInitializor(userId);
        }

        /// <summary>
        /// Ctor for recreating customer from database.
        /// </summary>
        /// <param name="id">Id of current customer in database.</param>
        /// <param name="userId">User's id attached to current customer.</param>
        public Customer(Guid id, Guid userId)
        {
            _isNew = false;
            _id = id;
            IDString = _id.ToString();
            _uId = userId;
            UserInitializor(userId);
            this.CSIs = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", MethodType.GetByQuery, "CustomerID='" + this.ID + "'", Guid.Empty));
            _selectedItemsCount = this.CSIs.Count;
            this.CSIsSum = CSIs.Sum(_csi => _csi.SDM.Cost);
        }

        /// <summary>
        /// Method gets customer by user.
        /// </summary>
        /// <param name="user">User attacehd to customer.</param>
        /// <returns>Customer object.</returns>
        public static Customer GetCustomerByUser(User user)
        {
            try
            {
                var packedObjects = MarketProxy.Proxy.GetData("Customer", Middleware.MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
                if (packedObjects.Count == 0)
                    return null;

                return CustomerMapper.Mapper.UnPack(packedObjects[0]);
            }
            catch
            { return null; }
        }

        /// <summary>
        /// Gets customer by id.
        /// </summary>
        /// <param name="customerId">Id of a customer in database.</param>
        /// <returns>Instance of a customer if found in database, otherwise null.</returns>
        internal static Customer GetById(Guid customerId)
        {
            var res = CustomerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Customer", MethodType.GetById, string.Empty, customerId));
            if (res != null)
            {
                res[0].IDString = res[0].ID.ToString();
                return res[0];
            }
            else
                return null;
        }

        /// <summary>
        /// Method gets customer instance by user name attached to it.
        /// </summary>
        /// <param name="userName">UserName attached to current customer.</param>
        /// <returns>Instance of Customer class if such customer exists in database, otherwise null.</returns>
        internal static Customer GetCustomerByUserName(string userName)
        {
            try
            {
                User user = UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", MethodType.GetByQuery, "Login='" + userName + "'", Guid.Empty)).FirstOrDefault();
                return GetCustomerByUser(user);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("error msg: " + ex.Message + Environment.NewLine + "occured in Customer->GetCustomerByUserName method.", "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        public string IDString { get; set; }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return this._uId; } }

        /// <summary>
        /// Gets or sets a first name of a current customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a middle name of a current customer.
        /// </summary>
        public string MiddaleName { get; set; }

        /// <summary>
        /// Gets or sets a last name of a current customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets an email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets gender of a current customer.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets sum of all selected items.
        /// </summary>
        public float CSIsSum { get; set; }

        /// <summary>
        /// Gets or sets age of a current customer.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Customer is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets login.
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        /// Gets password.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets sets a user profile attached to current customer.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Gets a list of selected merchandise to buy.
        /// </summary>
        public List<Merchandise> SelectedMerchandise
        {
            get
            {
                var res = new List<Merchandise>();
                if (CSIs == null || CSIs.Count == 0)
                    return res;

                foreach (CustomerSelectedItems si in CSIs)
                    res.Add(si.SDM.Merchendise);

                return res.Distinct().ToList();
            }
        }

        /// <summary>
        /// Gets or sets a list of CustomerSelectedItems where all information about merchandise and salesperson is stored.
        /// </summary>
        public List<CustomerSelectedItems> CSIs { get; set; }

        /// <summary>
        /// Gets number of selected items.
        /// </summary>
        public int SelectedItemsCount { get { return _selectedItemsCount; } }

        /// <summary>
        /// Method saves Customer.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(CustomerMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
            if (CSIs != null)
            {
                MarketProxy.Proxy.UpdateList(CustomerSelectedItemsMapper.Mapper.Pack(CSIs), Middleware.UpdateType.Save);
                foreach (CustomerSelectedItems csi in CSIs)
                    csi.IsNew = false;
            }
        }

        /// <summary>
        /// Method updates current object. Call if already exists!
        /// </summary>
        internal void Update()
        {
            this.CSIs = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", MethodType.GetByQuery, "CustomerID='" + this.ID + "'", Guid.Empty));
            this.User = UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", MethodType.GetById, string.Empty, _uId)[0]);
            _selectedItemsCount = this.CSIs.Count;
        }

        /// <summary>
        /// Method compares two instance of a Customer class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Customer c = obj as Customer;
            if (c == null) return false;
            if (c.ID == ID &&
                c.FirstName == FirstName &&
                c.MiddaleName == MiddaleName &&
                c.LastName == LastName &&
                c.Age == Age &&
                c.Gender == Gender &&
                c.User.ID == User.ID) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Display text representstion of a Customer class.
        /// </summary>
        /// <returns>First and Last Names of a Customer.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }

        private void UserInitializor(Guid userId)
        {
            this.User = UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", MethodType.GetById, string.Empty, userId)[0]);
            Login = User.Login;
            Password = User.Password;
        }

    }
}