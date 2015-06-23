// --------------------------------------------------------------------------
// <copyright file="SecurityTypeVM.cs" company="MK inc.">
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
    /// Class represents a Security type for spot.
    /// </summary>
    public class SecurityTypeVM : BaseVM
    {
        private SecurityType _securityType;

        /// <summary>
        /// Constructor for creating new SecurityType.
        /// </summary>
        /// <param name="name">Name of a type.</param>
        /// <param name="guards">Number of guards involved.</param>
        /// <param name="cost">Cost of the current type.</param>
        public SecurityTypeVM(string name, int guards, float cost)
        {
            _securityType = new SecurityType(name, guards, cost);
        }

        /// <summary>
        /// Ctor for creating new instance of SecurityTypeVM by instance of SecurityType.
        /// </summary>
        /// <param name="st">Instance of SecurityType.</param>
        public SecurityTypeVM(SecurityType st)
        {
            _securityType = st;
        }

        /// <summary>
        /// Constructor for recreating SecurityType from database.
        /// </summary>
        /// <param name="id">ID of SecurityType in database.</param>
        /// <param name="name">Name of a type.</param>
        /// <param name="guards">Number of guards involved.</param>
        /// <param name="cost">Cost of the current type.</param>
        public SecurityTypeVM(Guid id, string name, int guards, float cost)
        {
            _securityType = new SecurityType(id, name, guards, cost);
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _securityType.ID; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _securityType.IsNew; } }

        /// <summary>
        /// Gets a name of a security type.
        /// </summary>
        public string Name { get { return _securityType.Name; } }

        /// <summary>
        /// Gets a number of guards.
        /// </summary>
        public int Guards { get { return _securityType.Guards; } }

        /// <summary>
        /// Gets a cost of a current security type.
        /// </summary>
        public float Cost { get { return _securityType.Cost; } }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SecurityTypeMapper.Mapper.Pack(this._securityType), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a SecurityType class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SecurityTypeVM st = obj as SecurityTypeVM;
            if (st == null) return false;
            if (st.ID == ID) return true;
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
        /// <returns>Name, Guards, Cost.</returns>
        public override string ToString()
        { return string.Format("{0} ({1} ${2})", Name, Guards, Cost); }
    }
}