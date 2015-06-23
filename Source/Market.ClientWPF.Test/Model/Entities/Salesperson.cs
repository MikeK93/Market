// --------------------------------------------------------------------------
// <copyright file="Salesperson.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Market.Middleware;
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Enum represents a Gender Type.
    /// </summary>
    public enum GenderType
    {
        /// <summary>
        /// Represents Female.
        /// </summary>
        Female = 0,

        /// <summary>
        /// Represents Male.
        /// </summary>
        Male = 1
    }

    /// <summary>
    /// Class represents Salesperson.
    /// </summary>
    public class Salesperson
    {
        private Guid _userId;

        private bool _isNew = false;

        /// <summary>
        /// Ctor for cteatign new salesperson
        /// </summary>
        /// <param name="userId">User's id attached to current salesperson.</param>
        public Salesperson(Guid userId)
        {
            _isNew = true;
            _userId = userId;
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Ctor for recreating salesperson from database.
        /// </summary>
        /// <param name="id">Salesperson's ID in database.</param>
        /// <param name="userId">User's ID attached to current salesperon.</param>
        public Salesperson(Guid id, Guid userId)
        {
            ID = id;
            _userId = userId;
            _isNew = false;

            this.SDMs = SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", MethodType.GetByQuery, "SalespersonID='" + this.ID + "'", Guid.Empty));
            this.Clients = UpdateClients();
        }

        /// <summary>
        /// Method gets salesperson by user.
        /// </summary>
        /// <param name="user">User attached to salesperson.</param>
        /// <returns>Salesperson object.</returns>
        public static Salesperson GetSalespersonByUser(User user)
        {
            var packedObjects = MarketProxy.Proxy.GetData("Salesperson", MethodType.GetByQuery, "UserID='" + user.ID + "'", Guid.Empty);
            return SalespersonMapper.Mapper.UnPack(packedObjects[0]);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets id of user.
        /// </summary>
        public Guid UserID { get { return this._userId; } }

        /// <summary>
        /// Gets or sets a first name of a current salesperson.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a middle name of a current salesperson.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets a last name of a current salesperson.
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
        /// Gets or sets a gender of a current salesperson.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew
        { get { return _isNew; } }

        /// <summary>
        /// Gets User attached to current salesperson.
        /// </summary>
        public User User
        {
            get
            {
                return UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetById, string.Empty, _userId)[0]);
            }
        }

        /// <summary>
        /// Gets or sets a list of Salesperson-Dealer-Merchandise.
        /// </summary>
        public List<SDM> SDMs { get; set; }

        /// <summary>
        /// Gets a list of all merchandise, current salesperson is selling.
        /// </summary>
        public List<DM> DMs
        {
            get
            {
                var res = from sdm in SDMs.AsEnumerable() select sdm.DealerMerchandise;
                return res.ToList();
            }
        }

        /// <summary>
        /// Gets a list of dealers, current salesperson is working with.
        /// </summary>
        public List<Dealer> Dealers
        {
            get
            {
                var dealers = from d in SDMs.AsEnumerable() select d.Dealer;
                return dealers.GroupBy(d => d.ID).Select(g => g.First()).ToList();
            }
        }

        /// <summary>
        /// Gets a list of banks, current salesperson is using.
        /// </summary>
        public List<Bank> Banks
        {
            get
            {
                var bankSalespersons = BankSalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("BankSalesperson", Middleware.MethodType.GetByQuery, "SalespersonID='" + ID + "'", Guid.Empty));
                return (from bs in bankSalespersons.AsEnumerable() select bs.Bank).ToList();
            }
        }

        /// <summary>
        /// Gets a list of spots, current salesperson is using.
        /// </summary>
        public List<Spot> Spots { get { return SpotMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Spot", Middleware.MethodType.GetByQuery, "SalespersonID='" + ID + "'", Guid.Empty)); } }

        /// <summary>
        /// Gets a list of clients and order details.
        /// </summary>
        public List<CustomerSelectedItems> Clients { get; set; }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        {
            MarketProxy.Proxy.UpdateOne(SalespersonMapper.Mapper.Pack(this), Middleware.UpdateType.Save);
            if (this.SDMs != null)
                if (this.SDMs.Count > 0)
                {
                    MarketProxy.Proxy.UpdateList(SDMMapper.Mapper.Pack(this.SDMs), Middleware.UpdateType.Save);
                    foreach (SDM sdm in this.SDMs)
                        sdm.IsNew = false;
                }
        }

        /// <summary>
        /// Method compares two instance of a Salesperson class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            Salesperson s = obj as Salesperson;
            if (s == null) return false;
            if (s.ID == ID &&
                s.FirstName == FirstName &&
                s.LastName == LastName &&
                s.MiddleName == MiddleName &&
                s.LastName == LastName &&
                s.User == User &&
                s.Spots == Spots &&
                s.Gender == Gender) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Shows string representation of class.
        /// </summary>
        /// <returns>First and Last Names of salesperson.</returns>
        public override string ToString()
        { return FirstName + " " + LastName; }

        public List<CustomerSelectedItems> UpdateClients()
        {
            var res = new List<CustomerSelectedItems>();

            string q = string.Empty;
            foreach (var sdm in SDMs)
                q += " SalespersonDealerMerchandiseID = '" + sdm.ID + "' OR";

            q = q.Remove(q.Length - 3);
            var all = CustomerSelectedItemsMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("CustomerSelectedItems", Middleware.MethodType.GetByQuery, q, Guid.Empty));

            foreach (CustomerSelectedItems csi in all)
                if (csi.IsSubmited)
                    res.Add(csi);

            return res;
        }


        internal static Salesperson GetDealerByUser(Entities.User user)
        {
            throw new NotImplementedException();
        }
    }
}