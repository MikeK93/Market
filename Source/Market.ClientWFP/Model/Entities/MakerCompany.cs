// --------------------------------------------------------------------------
// <copyright file="MakerCompany.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Model;
using Market.Model.Mappers;

namespace Market.Model.Entities
{
    /// <summary>
    /// Class reperesent a MakerCompany.
    /// </summary>
    public class MakerCompany
    {
        private Guid _id;

        private bool _isNew;

        /// <summary>
        /// Constructor for creating new MakerCompany.
        /// </summary>
        public MakerCompany()
        {
            _id = Guid.NewGuid();
            _isNew = true;
        }

        /// <summary>
        /// Constructor for recreating MakerCompany form database.
        /// </summary>
        /// <param name="id">ID of MakerCompany in database.</param>
        public MakerCompany(Guid id)
        {
            _id = id;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets or sets a name of a company.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a Country where a company is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a City where a company is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Address where a company is located.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets a full address of a maker company. Combines Country, City and Address.
        /// </summary>
        public string FullAddress
        {
            get
            {
                return string.Format("{0}, {1}{2}", Country, City, (Address == string.Empty) ? string.Empty : ", " + Address);
            }
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(MakerCompanyMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a MakerCompany class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            MakerCompany mc = obj as MakerCompany;
            if (mc == null) return false;
            if (mc.ID == ID &&
                mc.Name == Name &&
                mc.Country == Country &&
                mc.Address == Address &&
                mc.City == City) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Shows string representation of class.
        /// </summary>
        /// <returns>Name and full address.</returns>
        public override string ToString()
        { return string.Format("{0} ({1})", Name, FullAddress); }
    }
}