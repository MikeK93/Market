// --------------------------------------------------------------------------
// <copyright file="SecurityType.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Data;
using Market.Data.Mappers;

namespace Market.Data.Entities
{
    /// <summary>
    /// Class represents a Security type for spot.
    /// </summary>
    public class SecurityType
    {
        private Guid _id;

        private bool _isNew;

        /// <summary>
        /// Constructor for creating new SecurityType.
        /// </summary>
        /// <param name="name">Name of a type.</param>
        /// <param name="guards">Number of guards involved.</param>
        /// <param name="cost">Cost of the current type.</param>
        public SecurityType(string name, int guards, float cost)
        {
            _id = Guid.NewGuid();
            Name = name;
            Guards = guards;
            Cost = cost;
            _isNew = true;
        }

        /// <summary>
        /// Constructor for recreating SecurityType from database.
        /// </summary>
        /// <param name="id">ID of SecurityType in database.</param>
        /// <param name="name">Name of a type.</param>
        /// <param name="guards">Number of guards involved.</param>
        /// <param name="cost">Cost of the current type.</param>
        public SecurityType(Guid id, string name, int guards, float cost)
        {
            _id = id;
            Name = name;
            Guards = guards;
            Cost = cost;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get { return _id; } }

        /// <summary>
        /// Gets a value indicating whether the object is new.
        /// </summary>
        public bool IsNew { get { return _isNew; } }

        /// <summary>
        /// Gets a name of a security type.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a number of guards.
        /// </summary>
        public int Guards { get; private set; }

        /// <summary>
        /// Gets a cost of a current security type.
        /// </summary>
        public float Cost { get; private set; }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(SecurityTypeMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method compares two instance of a SecurityType class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current object.</returns>
        public override bool Equals(object obj)
        {
            SecurityType st = obj as SecurityType;
            if (st == null) return false;
            if (st.ID == ID &&
                st.Name == Name &&
                st.Guards == Guards &&
                st.Cost == Cost) return true;
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