// --------------------------------------------------------------------------
// <copyright file="MakerCompany.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Command.ViewModel.Base;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class reperesent a MakerCompany.
    /// </summary>
    public class MakerCompanyVM : BaseVM
    {
        private MakerCompany _makerCompany;

        /// <summary>
        /// Constructor for creating new MakerCompany.
        /// </summary>
        public MakerCompanyVM()
        {
            _makerCompany = new MakerCompany();
        }

        /// <summary>
        /// Ctor for creating new instance of MakerCompanyVM by instance of MakerCompany.
        /// </summary>
        /// <param name="mc">Instance of MakerCompany.</param>
        public MakerCompanyVM(MakerCompany mc)
        {
            _makerCompany = mc;
        }

        /// <summary>
        /// Constructor for recreating MakerCompany form database.
        /// </summary>
        /// <param name="id">ID of MakerCompany in database.</param>
        public MakerCompanyVM(Guid id)
        {
            _makerCompany = new MakerCompany(id);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _makerCompany.ID; } }

        /// <summary>
        /// Gets or sets a name of a company.
        /// </summary>
        public string Name
        {
            get { return _makerCompany.Name; }
            set
            {
                if (value == _makerCompany.Name)
                    return;

                _makerCompany.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets a Country where a company is located.
        /// </summary>
        public string Country
        {
            get { return _makerCompany.Country; }
            set
            {
                if (value == _makerCompany.Country)
                    return;

                _makerCompany.Country = value;
                OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets a City where a company is located.
        /// </summary>
        public string City
        {
            get { return _makerCompany.City; }
            set
            {
                if (value == _makerCompany.City)
                    return;

                _makerCompany.City = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets Address where a company is located.
        /// </summary>
        public string Address
        {
            get { return _makerCompany.Address; }
            set
            {
                if (value == _makerCompany.Address)
                    return;

                _makerCompany.Address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _makerCompany.IsNew; } }

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
        { MarketProxy.Proxy.UpdateOne(MakerCompanyMapper.Mapper.Pack(this._makerCompany), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a MakerCompany class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            MakerCompany mc = obj as MakerCompany;
            if (mc == null) return false;
            if (mc.ID == ID) return true;
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